<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button></ion-back-button>
        </ion-buttons>
        <ion-title>{{ restaurant.name || "Restaurant" }}</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <!-- content -->
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {IonBackButton, IonButtons, IonContent, IonHeader, IonPage, IonTitle, IonToolbar} from '@ionic/vue';
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
    IonButtons
  },
});

</script>

<style scoped>

</style>
