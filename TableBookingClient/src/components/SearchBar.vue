<template>
  <ion-toolbar>
    <ion-searchbar slot="start"/>
    <ion-buttons slot="end">
      <ion-button>
        <ion-icon slot="icon-only" :icon="optionsSharp"></ion-icon>
      </ion-button>
    </ion-buttons>
  </ion-toolbar>
  <ion-toolbar>
    <ion-segment value="list">
      <ion-segment-button value="list">
        List
      </ion-segment-button>
      <ion-segment-button value="map">
        Map
      </ion-segment-button>
    </ion-segment>
  </ion-toolbar>
</template>

<script lang="ts">
import { IonToolbar, IonSearchbar, IonButtons, IonButton, IonIcon, IonSegment, IonSegmentButton } from '@ionic/vue';
import { optionsSharp } from 'ionicons/icons';
import { defineComponent } from 'vue';
export default defineComponent({
  name: 'SearchBar',
  components: {
    IonToolbar,
    IonSearchbar,
    IonButtons,
    IonButton,
    IonIcon,
    IonSegment,
    IonSegmentButton
  },
  setup() {
    return { optionsSharp };
  }
});
</script>

<style scoped>
  ion-searchbar{
    padding: 10px;
  }
  ion-buttons{
    padding-right: 5px;
  }
</style>