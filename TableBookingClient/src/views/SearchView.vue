<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    <ion-content>
      <RestaurantCard :restaurant-name="'TestName'" :restaurant-type="'TestType'" :restaurant-id="'123'" />
      <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
        <RestaurantCard :restaurant-name=restaurant.name :restaurant-type=restaurant.type :restaurant-id=restaurant.id />
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
  type: string,
  image: string
}

export default defineComponent({
  name: 'SearchView',
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
  async mounted() {
    await this.getRestaurants();
    console.log(this.restaurants);
  },
  components: {
    RestaurantCard,
    IonContent,
    IonPage,
    SearchBar,
    IonHeader,
    IonList
  },
});
</script>

<style scoped>

</style>