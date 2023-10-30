<template>
    <ion-page>
      <ion-header>
        <ion-toolbar>
          <ion-buttons slot="start">
            <ion-back-button></ion-back-button>
          </ion-buttons>
          <ion-title>Book a table at {{ restaurant.name }}</ion-title>
        </ion-toolbar>
      </ion-header>
      <ion-content>
        <ion-card>
          
          <ion-card-content>
            <h1>When?</h1>
            <ion-datetime></ion-datetime>
            <h1>How many people?</h1>
            <IonInput type="number" placeholder="Number of people"></IonInput>
          </ion-card-content>
        </ion-card>
      </ion-content>
    </ion-page>
  </template>
  
  <script setup lang="ts">
  import  { IonPage, IonHeader, IonToolbar, IonButtons, IonBackButton, IonTitle, IonContent, IonCard, IonCardContent, IonCardHeader, IonCardSubtitle, IonCardTitle, IonDatetime, IonButton, IonInput } from "@ionic/vue";
  import type { Restaurant } from "../../models";

  import axios from "axios";
  import { onMounted } from "vue";
  import { restaurantPlaceholders } from "../../restaurants";
  
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
  
  const bookTable = () => {
    console.log("Book table");
  };
  
  </script>
  
  <style scoped>
  /*Display the restaurant card in the center center of the page in the middle*/
  ion-card {
    margin: 10px auto;
    height: auto;
    max-width: calc(100% - 20px);
  }
  h1{
    margin: 5px;
  }
  </style>
  