<template>
  <ion-toolbar>
    <ion-searchbar slot="start" v-model="searchOptions.query" :debounce="1000" @ionInput="onSearch($event)" />
    <SearchOptions @options-updated="updateOptions" />
  </ion-toolbar>
  <ion-toolbar>
    <ion-segment value="list" @ionChange="onSegmentChange">
      <ion-segment-button value="list">List</ion-segment-button>
      <ion-segment-button value="map">Map</ion-segment-button>
    </ion-segment>
  </ion-toolbar>
</template>

<script setup lang="ts">
import { IonToolbar, IonSearchbar, IonSegment, IonSegmentButton } from '@ionic/vue';
import router from "@/router";
import SearchOptions from "./SearchOptions.vue"
import { ref, defineEmits } from "vue";
import { SearchOptions as SearchOptionsModel, priceRange, sortingMethod } from "@/models";

const searchOptions = ref<SearchOptionsModel>({
  price: priceRange.$,
  sort: sortingMethod.popular,
  query: ""
});

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

const onSegmentChange = (e: CustomEvent) => {
  router.push(e.detail.value);
}
</script>

<style scoped>
ion-searchbar {
  padding: 10px;
}
</style>