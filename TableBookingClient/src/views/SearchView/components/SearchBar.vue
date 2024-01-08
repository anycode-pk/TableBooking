<template>
  <ion-toolbar>
    <ion-searchbar slot="start" v-model="searchOptions.query" :debounce="1000" @ionInput="onSearch($event)" />
    <SearchOptions :options="searchOptions" @options-updated="updateOptions" />
  </ion-toolbar>
  <ion-toolbar>
    <ion-segment v-model="selectedSegment" @ionChange="onSegmentChange">
      <ion-segment-button value="list">List</ion-segment-button>
      <ion-segment-button value="map">Map</ion-segment-button>
    </ion-segment>
  </ion-toolbar>
</template>

<script setup lang="ts">
import { IonToolbar, IonSearchbar, IonSegment, IonSegmentButton } from '@ionic/vue';
import SearchOptions from "./SearchOptions.vue"
import { ref, defineEmits, defineProps, watch, onMounted } from "vue";
import { useRouter } from 'vue-router';
import { SearchOptions as SearchOptionsModel, priceRange, sortingMethod } from "@/models";

const router = useRouter();

const selectedSegment = ref<string>("list");

const props = defineProps({
  options: {
    type: Object as () => SearchOptionsModel,
    required: true
  }
})

const searchOptions = ref<SearchOptionsModel>({ ...props.options });

watch(
  () => props.options,
  (newOptions) => {
    searchOptions.value = { ...newOptions };
  },
  { deep: true }
);

const emit = defineEmits(['options-updated'])

const onSearch = (e: CustomEvent) => {
  searchOptions.value.query = e.detail.value;
  emit('options-updated', searchOptions.value);
}
const updateOptions = (options: SearchOptionsModel) => {
  searchOptions.value.price = options.price;
  searchOptions.value.sort = options.sort;
  emit('options-updated', searchOptions.value);
}

onMounted(() => {
  selectedSegment.value = router.currentRoute.value.path.split("/")[2];
})

const onSegmentChange = (e: CustomEvent) => {
  selectedSegment.value = e.detail.value as string;
  router.replace({
    path: "/search/" + e.detail.value,
    query: {
      price: searchOptions.value.price,
      sort: searchOptions.value.sort,
      query: searchOptions.value.query,
    },
  });
}
</script>

<style scoped>
ion-searchbar {
  padding: 10px;
}
</style>