<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button></ion-back-button>
        </ion-buttons>
        <ion-title>{{ "Booking " + restaurant.name }}</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-card>
        <img alt="Restaurant image" v-bind:src="restaurant.imageUrl" />
        <ion-card-content>
          <ion-datetime id="date" display-format="DD MMM YYYY" picker-format="DD MMM YYYY"
            placeholder="Select Date"></ion-datetime>
          <NumberPicker />
          <div id="button">
            <ion-button @click="bookTable">
              <ion-icon slot="start" :icon="time"></ion-icon>
              <ion-label>Book a table</ion-label>
            </ion-button>
          </div>
        </ion-card-content>
      </ion-card>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">

import { IonPage, IonIcon, IonCardContent, IonLabel, IonCard, IonCardTitle, IonCardHeader, IonCardSubtitle, IonButton, IonBackButton, IonButtons, IonTitle, IonHeader, IonContent, IonToolbar, } from "@ionic/vue";
import { heartSharp, shareSharp, time } from "ionicons/icons";
import type { Restaurant } from "@/models";
import axios from "axios";
import { onMounted } from "vue";
import { restaurantPlaceholders } from "@/restaurants";
import RestaurantRating from "@/views/components/RestaurantRating.vue";
import NumberPicker from "@/views/BookRestaurantView/components/NumberPicker.vue";
import router from "@/router";

let restaurant: Restaurant;
restaurant = restaurantPlaceholders[0];

async function getRestaurant(): Promise<void> {
  const getRestaurantsResponse = await axios.get<Restaurant>('https://localhost:7012/api/Restaurant/' + restaurant.id);
  let restaurantData: Restaurant = getRestaurantsResponse.data;
  if (restaurantData) {
    restaurant = restaurantData;
  }
}
onMounted(async () => {
  await getRestaurant();
})
const likeRestaurant = () => {
  console.log("Like restaurant");
};
const shareRestaurant = () => {
  console.log("Share restaurant");
};

const bookTable = () => {
  console.log("Book table");
  //TODO: Insert a request to the backend to book a table
  //go to success page
  router.push("/book/success");
};

</script>

<style scoped>
/*Display the restaurant card in the center center of the page in the middle*/
ion-card {
  margin: 10px auto;
  height: auto;
  max-width: calc(100% - 20px);
}

#time {
  float: right;
}

ion-card-subtitle {
  margin: 0;
}

ion-card-content {
}

#button {
  display: flex;
  justify-content: center;
}</style>