<template>
  <ion-card :router-link='linkToRestaurant'>
    <img class="restaurant-card-image" alt="Restaurant image" v-bind:src="restaurant.imageUrl" />
    <div class="header-row">
      <ion-card-header>
        <ion-card-subtitle>{{ restaurant.type || 'Type' }}</ion-card-subtitle>
        <ion-card-title class="card-title">{{ props.restaurant.name || 'Name' }}</ion-card-title>
        <div class="time-container">
          <IonLabel class="time-label">{{ restaurant.openTime + '-' + restaurant.closeTime }}</IonLabel>
          <IonIcon class="time-icon" :icon="time" />
        </div>
        <RestaurantRating v-bind:rating="restaurant.rating" />
      </ion-card-header>
      <div class="card-buttons">
        <ion-button @click.stop="likeRestaurant" fill="clear">
          <ion-icon slot="icon-only" :icon="heartSharp" />
        </ion-button>
        <ion-button @click.stop="shareRestaurant" fill="clear">
          <ion-icon slot="icon-only" :icon="shareSharp" />
        </ion-button>
      </div>
    </div>
  </ion-card>
</template>

<script setup lang="ts">
import { IonCard, IonCardHeader, IonCardSubtitle, IonCardTitle, IonButton, IonIcon, IonLabel, IonNavLink } from "@ionic/vue";
import { heartSharp, shareSharp, time } from "ionicons/icons";
import { defineProps } from "vue";
import type { Restaurant } from "@/models";
import RestaurantRating from "@/views/components/RestaurantRating.vue";

const props = defineProps<{
  restaurant: Restaurant
}>();

const linkToRestaurant = `/restaurant/${props.restaurant.id}`;
const likeRestaurant = () => {
  console.log("Like restaurant");
};
const shareRestaurant = () => {
  console.log("Share restaurant");
};

</script>

<style>
@media (min-width: 768px) {
  ion-card {
    width: 50%;
  }

  img {
    width: 100%;
    height: 200px;
    object-fit: cover;
  }
}

ion-card {
  width: calc(100% - 20px);
}


.header-row {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  height: 100%;
  align-items: center;
}

.card-buttons {
  display: flex;
  flex-direction: row-reverse;
  align-items: center;
  width: 50%;
}

.card-content-row {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.time-container {
  display: flex;
  flex-direction: row;
  align-items: center;
}

.time-icon {
  height: 24px;
}

.time-label {
  padding: 5px;
  margin-top: 2px;
}

.restaurant-card-image {
  width: 100%;
  height: 200px;
  object-fit: cover;
}

.restaurant-card-title {
  display: flex;
  flex-direction: row;
  justify-content: space-around;
  height: 100%;
}

.time-label {
  padding-left: 0;
  margin: 0;
}
.card-title {
  margin-top: 2px;
}
</style>