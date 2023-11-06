<template>
  <ion-page>
    <ion-header>
      <SearchBar @search-updated="updateQuery"></SearchBar> <!-- To do: Bind Search Options -->
    </ion-header>
    <IonContent>
      <ion-router-outlet>
      </ion-router-outlet>
    </IonContent>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonHeader, IonRouterOutlet, IonContent } from "@ionic/vue";
import SearchBar from "@/views/SearchView/components/SearchBar.vue";
import { Restaurant, priceRange, sortingMethod, SearchOptions } from "@/models";
import { restaurantPlaceholders } from "@/restaurants";
import axios from "axios";
import { provide, onMounted, ref } from "vue";

const searchOptions = ref<SearchOptions>({
  price: priceRange.$,
  sort: sortingMethod.popular,
  query: ""
});

//Todo: Bind Search Options
//Todo: Query in the URL

const updateQuery = (query: string) => {
  searchOptions.value.query = query;
  fetchRestaurants();
};

const endpoint = "https://localhost:7012/Restaurant/GetAllRestaurants"

const restaurants = ref<Restaurant[]>([]);

onMounted(async () => {
  fetchRestaurants();
});

const fetchRestaurants = async () => {
  try {
    const getRestaurantsResponse = await axios.get<Restaurant[]>(endpoint, {
      params: {
        //price: searchOptions.value.price,
        // sort: searchOptions.value.sort,
        //query: searchOptions.value.query,
      },
    });
    restaurants.value.push(...getRestaurantsResponse.data);
  } catch (error) {
    console.error("Error fetching data: ", error);
    restaurants.value = restaurantPlaceholders;
  }
};

provide("restaurants", restaurants);
</script>

<style scoped></style>