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
            <img alt="../assets/img/RestaurantPlaceholder.jpg" src=""/>
            <div class="header-row">
                <ion-card-header>
                    <ion-card-subtitle>{{ restaurant.type || 'Type' }}</ion-card-subtitle>
                    <ion-card-title>{{ restaurant.name || 'Name' }}</ion-card-title>
                    <div class="time-container">
                        <IonIcon class="time-icon" :icon="time"/>
                        <IonLabel class="time-label">8:00-21:00</IonLabel>
                    </div>
                </ion-card-header>
                <div class="card-buttons">
                    <ion-button fill="clear">
                        <ion-icon slot="icon-only" :icon="heartSharp"/>
                    </ion-button>
                    <ion-button  fill="clear">
                        <ion-icon slot="icon-only" :icon="shareSharp"/>
                    </ion-button>
                </div>
            </div>
            <ion-card-content>
                <p>{{ restaurant.shortDescription || 'Short description' }}</p>
            </ion-card-content>
        </ion-card>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">

import {IonPage, IonIcon, IonCardContent, IonLabel, IonCard, IonCardTitle, IonCardHeader, IonCardSubtitle, IonButton, IonBackButton, IonButtons, IonTitle, IonHeader, IonContent, IonToolbar, } from "@ionic/vue";
import {heartSharp, shareSharp, time} from "ionicons/icons";
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
