<template>
  <ion-page>
    <ion-content>
      <ion-list v-for="restaurant in restaurants" :key="restaurant.id">
        <RestaurantCard :restaurant-name=restaurant.name :restaurant-type=restaurant.type :restaurant-image="restaurant.image" />
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import axios from "axios";
import {onMounted, ref} from "vue";
import { IonPage, IonContent, IonList } from "@ionic/vue";
import RestaurantCard from "@/views/SearchView/components/RestaurantCard.vue";

interface Restaurant {
  id: string,
      name: string,
      type: string,
      image: string
}

const restaurants: any = ref([
  {id: "1", name: "Restaurant 1", type: "Italian", image: "https://www.italianfood.net/wp-content/uploads/2019/03/italian-food-recipes.jpg"},
  {id: "2", name: "Restaurant 2", type: "Hamburgers", image: "https://www.italianfood.net/wp-content/uploads/2019/03/italian-food-recipes.jpg"},
  {id: "3", name: "Restaurant 3", type: "Asian", image: "https://www.italianfood.net/wp-content/uploads/2019/03/italian-food-recipes.jpg"},
])
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
ion-list {
  display: flex;
  flex-direction: column;
  align-items: center;
}
</style>