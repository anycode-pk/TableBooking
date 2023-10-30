<template>
  <ion-page>
    <ion-content>
      <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
        <RestaurantCard :restaurant="restaurant" />
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import axios from "axios";
import { onMounted } from "vue";
import { IonPage, IonContent, IonList } from "@ionic/vue";
import RestaurantCard from "@/views/SearchView/components/RestaurantCard.vue";
import type { Restaurant } from "@/models";
import { restaurantPlaceholders } from "@/restaurants";

const restaurants: Restaurant[] = [];
restaurants.push(...restaurantPlaceholders);

async function getRestaurants(): Promise<void> {
  const getRestaurantsResponse = await axios.get<Restaurant[]>('https://localhost:7012/api/Restaurant');
  let restaurantData: Restaurant[] = getRestaurantsResponse.data;
  for (let restaurant in restaurantData) {
    restaurants.push(restaurantData[restaurant]);
  }
}
onMounted(async () => {
  await getRestaurants();
})
</script>

<style scoped>
ion-list {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>