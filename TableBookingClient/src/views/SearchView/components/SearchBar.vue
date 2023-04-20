<template>
  <ion-toolbar>
    <ion-searchbar slot="start"/>
    <SearchOptions/>
  </ion-toolbar>
  <ion-toolbar>
    <ion-segment value="list" @ionChange="onSegmentChange">
      <ion-segment-button value="list">List</ion-segment-button>
      <ion-segment-button value="map">Map</ion-segment-button>
    </ion-segment>
  </ion-toolbar>
</template>

<script setup lang="ts">
import {IonToolbar, IonSearchbar, IonSegment, IonSegmentButton} from '@ionic/vue';
import SearchOptions from "@/views/SearchView/components/SearchOptions.vue";
import router from "@/router";

const onSegmentChange = (e: CustomEvent) => {
  //push segment value to router
    router.push(e.detail.value);
}
</script>

<style scoped>
  ion-searchbar{
    padding: 10px;
  }

</style>