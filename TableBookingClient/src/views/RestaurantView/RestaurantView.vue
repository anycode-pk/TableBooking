<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button></ion-back-button>
        </ion-buttons>
        <ion-title>{{ restaurant.name }}</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-card>
        <img alt="image of restaurant" src="../../assets/img/RestaurantPlaceholder.jpg" />
        <ion-card-header>
          <ion-card-title>{{ restaurant && restaurant.name || "Restaurant" }}</ion-card-title>
          <div id="time">
            <IonIcon :icon="time"/>
            <IonLabel> 8:00-21:00</IonLabel>
          </div>
          <ion-card-subtitle>{{ restaurant && restaurant.type || "Type" }}</ion-card-subtitle>
        </ion-card-header>
        <ion-card-content>
          <p>{{ restaurant && restaurant.description || loremIpsum }}</p>
        </ion-card-content>
          <IonButton expand="block" color="primary" routerLink="/book-restaurant/{{restaurant.id}}">Book a table</IonButton>
      </ion-card>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">

import {IonPage, IonIcon, IonCardContent, IonLabel, IonCard, IonCardTitle, IonCardHeader, IonCardSubtitle, IonButton, IonBackButton } from "@ionic/vue";
import { time } from "ionicons/icons";
import type { Restaurant } from "@/models";
import {LoremIpsum} from "lorem-ipsum";
import axios from "axios";
import {onMounted} from "vue";
import router from "@/router";

const loremIpsum :string = new LoremIpsum({
    sentencesPerParagraph: {
        max: 8,
        min: 4
    },
    wordsPerSentence: {
        max: 16,
        min: 4
    }
}).generateParagraphs(1);

let restaurant :Restaurant = {
    //Get id from the url "restaurant/id"
    id: router.currentRoute.value.fullPath.split("/")[2],
    name: "Restaurant",
    type: "Type",
    description: loremIpsum,
    imageUrl: "https://www.italianfood.net/wp-content/uploads/2019/03/italian-food-recipes.jpg",
};

async function getRestaurant(): Promise<void>{
    const getRestaurantsResponse = await axios.get<Restaurant>('https://localhost:7012/api/Restaurant/' + restaurant.id);
    let restaurantData : Restaurant = getRestaurantsResponse.data;
    if (restaurantData){
        restaurant = restaurantData;
    }
}
onMounted(async () => {
    await getRestaurant();
})

</script>

<style scoped>
  /*Display the restaurant card in the center center of the page in the middle*/
  ion-card {
    margin: 10px auto;
    height: auto;
    max-width: calc(100% - 20px);
  }
  #time{
    float: right;
  }
  img{}
  ion-card-subtitle{
      margin: 0;
  }


</style>
