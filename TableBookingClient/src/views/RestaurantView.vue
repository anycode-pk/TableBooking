<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button></ion-back-button>
        </ion-buttons>
        <ion-title>{{ restaurant.name || "Placeholder Restaurant" }}</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-card>
        <img alt="image of restaurant" :src="restaurant.image" />
        <ion-card-header>
          <ion-card-title>{{ restaurant.name || "Placeholder Restaurant" }}</ion-card-title>
          <ion-card-subtitle>{{ restaurant.type || "Placeholder Type" }}</ion-card-subtitle>
        </ion-card-header>
      </ion-card>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonBackButton,
  IonButtons,
  IonContent,
  IonHeader,
  IonPage,
  IonTitle,
  IonToolbar,
  IonCard,
  IonCardHeader, IonCardSubtitle, IonCardTitle
} from '@ionic/vue';
import { defineComponent } from 'vue';
import axios from "axios";

interface Restaurant {
  id: string,
  name: string,
  type: string,
  image: string
}

export default defineComponent({
  name: 'RestaurantView',
  data () {
    return {
      restaurant: {} as Restaurant
    }
  },
  methods: {
    async getRestaurant() {
      const query = 'https://localhost:7012/api/Restaurant/' + this.id;
      const getRestaurantsResponse = await axios.get<Restaurant>(query);
      this.restaurant = getRestaurantsResponse.data;
    },
  },
  async mounted() {
    await this.getRestaurant();
  },
  props: {
    id: String
  },
  components: {
    IonContent,
    IonHeader,
    IonPage,
    IonTitle,
    IonToolbar,
    IonBackButton,
    IonButtons,
    IonCard,
    IonCardHeader,
    IonCardTitle,
    IonCardSubtitle
  },
});

</script>

<style scoped>
  /*Display the restaurant card in the center center of the page in the middle*/
  ion-card {

  }
</style>
