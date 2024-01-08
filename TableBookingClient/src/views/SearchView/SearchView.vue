<template>
  <ion-page>
    <ion-header>
      <SearchBar :options="searchOptions" @options-updated="updateQuery"></SearchBar>
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
import { useRouter, useRoute } from "vue-router";

const router = useRouter();
const route = useRoute();

const searchOptions = ref<SearchOptions>({
  price: priceRange.$,
  sort: sortingMethod.popular,
  query: ""
});

const updateQuery = (options: SearchOptions) => {
  searchOptions.value = options;
  fetchRestaurants();

  // Update the URL with the new query parameters
  router.replace({
    path: router.currentRoute.value.path,
    query: {
      price: options.price,
      sort: options.sort,
      query: options.query,
    },
  });
};

const endpoint = "https://localhost:7012/api/GetAllRestaurants"

const restaurants = ref<Restaurant[]>([]);

onMounted(async () => {
  // Check the route's query parameters and update the searchOptions accordingly
  if (route.query.price) {
    searchOptions.value.price = route.query.price as unknown as priceRange;
  }
  if (route.query.sort) {
    searchOptions.value.sort = route.query.sort as unknown as sortingMethod;
  }
  if (route.query.query) {
    searchOptions.value.query = route.query.query as string;
  }
  console.log(searchOptions.value);
  fetchRestaurants();
});

const fetchRestaurants = async () => {
  try {
    const getRestaurantsResponse = await axios.get<Restaurant[]>(endpoint, {
      params: {
        price: searchOptions.value.price,
        // sort: searchOptions.value.sort,
        restaurantName: searchOptions.value.query,
      },
    });
    restaurants.value = getRestaurantsResponse.data;
  } catch (error) {
    console.error("Error fetching data: ", error);
    restaurants.value = restaurantPlaceholders;
  }
};

provide("restaurants", restaurants);
</script>

<style scoped></style>