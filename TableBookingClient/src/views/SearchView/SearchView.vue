<template>
  <ion-page>
    <ion-header>
      <SearchBar></SearchBar> <!-- To do: Bind Search Options -->
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
});
const query = "https://localhost:7012/api/Restaurant"

const updateSearchOptions = (newSearchOptions: SearchOptions) => {
  searchOptions.value = newSearchOptions;
};

const restaurants = ref<Restaurant[]>([]);

onMounted(async () => {
  try {
    const getRestaurantsResponse = await axios.get<Restaurant[]>(query, {
      params: {
        price: searchOptions.value.price,
        sort: searchOptions.value.sort,
      },
    });
    let restaurantData: Restaurant[] = [];
    restaurants.value.push(...getRestaurantsResponse.data);
  } catch (error) {
    console.error("Error fetching data: ", error);
    restaurants.value.push(...restaurantPlaceholders);
  }
});

provide("restaurants", restaurants);
</script>

<style scoped></style>