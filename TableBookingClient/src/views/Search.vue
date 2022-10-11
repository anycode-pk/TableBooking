<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    <ion-content>
        <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
          <restaurant-card :restaurant-name=restaurant.name />
        </ion-list>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {IonPage, IonContent, IonHeader, IonList} from "@ionic/vue";
import { defineComponent } from 'vue';
import axios from "axios";
import RestaurantCard from "@/components/RestaurantCard.vue";
import SearchBar from "@/components/SearchBar.vue";

interface Restaurant {
  id: string,
  name: string,
  type: string
}

export default defineComponent({
  name: 'Search',
  data() {
    return {
      restaurants: [] as Restaurant[],
      fetchingRestaurants: false
    }
  },
  methods: {
    async getRestaurants() {
      const getRestaurantsResponse = await axios.get<Restaurant[]>('https://localhost:7012/api/Restaurant')
      this.restaurants = getRestaurantsResponse.data
    },
  },
  components: {
    RestaurantCard,
    IonContent,
    IonPage,
    SearchBar,
    IonHeader,
    IonList
  },
  async mounted() {
    await this.getRestaurants();
    console.log(this.restaurants);
  }
});
</script>

<style scoped>

</style>