<template>
  <ion-page>
    <ion-header>
      <SearchBar />
    </ion-header>
    <ion-router-outlet>

    </ion-router-outlet>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonHeader, IonRouterOutlet } from "@ionic/vue";
import SearchBar from "@/views/SearchView/components/SearchBar.vue";

import { Restaurant, priceRange, sortingMethod } from "@/models";
import { restaurantPlaceholders } from "@/restaurants";
import axios from "axios";
import { provide } from "vue";

let price: priceRange = priceRange.$;

let sort: sortingMethod = sortingMethod.popular;

let query = "https://localhost:7012/api/Restaurant"

provide("restaurants", getRestaurants());

async function getRestaurants(): Promise<Restaurant[]> {
  const getRestaurantsResponse = await axios.get<Restaurant[]>(query, {
    params: {
      price: price,
      sort: sort,
    },

  });
  let restaurantData: Restaurant[] = getRestaurantsResponse.data;
  restaurantData.push(...restaurantPlaceholders);
  return restaurantData;
}
</script>

<style scoped></style>