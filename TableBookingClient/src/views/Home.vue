<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Home</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <!-- content -->
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {IonContent, IonHeader, IonPage, IonTitle, IonToolbar} from '@ionic/vue';
import { defineComponent } from 'vue';
import axios from "axios";

export default defineComponent({
  name: 'Home',
  components: {
    IonContent,
    IonHeader,
    IonPage,
    IonTitle,
    IonToolbar
  },

  data() {
    return {
      restaurants: [] as any[],
      fetchingRestaurants: false
    }
  },

  methods: {
    async getRestaurants() {
      const getRestaurantsResponse = await axios.get<any>('https://localhost:7012/api/Restaurant')
      this.restaurants = getRestaurantsResponse.data
    },
  },

  async mounted() {
    await this.getRestaurants();
  }

});

</script>

<style scoped>

</style>
