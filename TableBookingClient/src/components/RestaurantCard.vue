<template>
    <ion-card :router-link='linkToRestaurant'>
      <img alt="../assets/img/RestaurantPlaceholder.jpg" src="../assets/img/RestaurantPlaceholder.jpg"/>
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
          <ion-card-title>{{ restaurantName || 'Name' }}</ion-card-title>
          <ion-card-subtitle>{{ restaurantType || 'Type' }}</ion-card-subtitle>
        </ion-card-header>
      </ion-toolbar>
    </ion-card>
</template>

<script lang="ts">
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
  name: 'RestaurantCard',
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
  props: {
    restaurantId: String,
    restaurantName: String,
    restaurantType: String
  },
  setup() {
    return {
      heartSharp,
      shareSharp
    }
  },
  data() {
    return {
      linkToRestaurant: "/restaurant/" + this.restaurantId
    }
  }
});
</script>

<style>
  img{

  }
</style>