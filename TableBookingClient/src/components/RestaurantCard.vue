<template>
  <ion-card>
    <img src="../assets/img/RestaurantPlaceholder.jpg"/>
    <ion-toolbar>
      <ion-buttons slot="primary">
        <ion-button fill="clear">
          <ion-icon slot="icon-only" :icon="heartSharp"/>
        </ion-button>
        <ion-button fill="clear">
          <ion-icon slot="icon-only" :icon="shareSharp"/>
        </ion-button>
      </ion-buttons>
      <ion-card-header>
        <ion-card-title>Alfredo's</ion-card-title>
        <ion-card-subtitle>Italian</ion-card-subtitle>
      </ion-card-header>
    </ion-toolbar>
  </ion-card>
</template>

<script>
import {
  IonCard,
  IonCardHeader,
  IonCardSubtitle,
  IonCardTitle,
  IonButton,
  IonIcon,
  IonButtons,
  IonToolbar
} from '@ionic/vue';
import { heartSharp, shareSharp } from 'ionicons/icons'
import { defineComponent } from 'vue';

export default defineComponent({
  components: {
    IonCard,
    IonCardHeader,
    IonCardSubtitle,
    IonCardTitle,
    IonButton,
    IonButtons,
    IonIcon,
    IonToolbar
  },
  setup() {
    return {
      heartSharp,
      shareSharp
    }
  }
});
</script>

<style>
  img{

  }
</style>