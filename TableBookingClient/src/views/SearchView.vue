<template>
  <ion-page>
    <ion-header>
      <SearchBar/>
    </ion-header>
    <ion-content>
      <RestaurantCard :restaurant-name="'TestName'" :restaurant-type="'TestType'" :restaurant-id="'123'" />
      <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
        <RestaurantCard :name=restaurant.name :type=restaurant.type :image="restaurant.image" />
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
  import axios from "axios";
  import {onMounted, ref} from "vue";
  import { IonPage, IonHeader, IonContent, IonList } from "@ionic/vue";
  import SearchBar from "@/components/SearchBar.vue";
  import RestaurantCard from "@/components/RestaurantCard.vue";

  interface Restaurant {
    id: string,
    name: string,
    type: string,
    image: string
  }

  const restaurants: any = ref([])
  async function getRestaurants(): Promise<void>{
    const getRestaurantsResponse = await axios.get<Restaurant[]>('https://localhost:7012/api/Restaurant')
    let restaurantData = getRestaurantsResponse.data;
    for (let restaurant in restaurantData){
      restaurants.value.push(restaurantData[restaurant]);
    }
  }
  onMounted(async () => {
    await getRestaurants();
    console.log(restaurants.value);
  })
</script>

<style scoped>

</style>