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

<script lang="ts">
import {IonToolbar, IonSearchbar, IonSegment, IonSegmentButton} from '@ionic/vue';
import { defineComponent } from 'vue';
import SearchOptions from "@/views/SearchView/components/SearchOptions.vue";

export default defineComponent({
  name: 'SearchBar',
  components: {
    SearchOptions,
    IonToolbar,
    IonSearchbar,
    IonSegment,
    IonSegmentButton,
  },
  methods: {
    onSegmentChange(event: CustomEvent) {
      const value = event.detail.value;
      this.$router.push(value);
    }
  }
});
</script>

<style scoped>
  ion-searchbar{
    padding: 10px;
  }

</style>