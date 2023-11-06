<template>
  <ion-toolbar>
    <ion-searchbar slot="start" v-model="searchValue" :debounce="1000" @ionInput="onSearch($event)" />
    <SearchOptions />
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
import { defineProps, ref, defineEmits } from "vue";

defineProps(['searchOptions'])
const emit = defineEmits(['search-updated'])
const searchValue = ref('');

const onSearch = (e: CustomEvent) => {
  searchValue.value = e.detail.value;
  emit('search-updated', e.detail.value);
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