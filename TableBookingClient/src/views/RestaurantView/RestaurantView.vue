<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button></ion-back-button>
        </ion-buttons>
        <ion-title>{{ restaurant.name || "Placeholder Restaurant" }}</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-card>
        <img alt="image of restaurant" src="../../assets/img/RestaurantPlaceholder.jpg" />
        <ion-card-header>
          <ion-card-title>{{ restaurant.name || "Placeholder Restaurant" }}</ion-card-title>
          <div id="time">
            <IonIcon :icon="time()"/>
            <IonLabel> 8:00-21:00</IonLabel>
          </div>
          <ion-card-subtitle>{{ restaurant.type || "Placeholder Type" }}</ion-card-subtitle>
        </ion-card-header>
        <ion-card-content>
          lorem ipsum Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.
        </ion-card-content>
      </ion-card>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonBackButton,
  IonButtons,
  IonContent,
  IonHeader,
  IonPage,
  IonTitle,
  IonToolbar,
  IonCard,
  IonCardHeader, IonCardSubtitle, IonCardTitle, IonItem, IonIcon, IonLabel, IonCardContent
} from '@ionic/vue';
import { defineComponent } from 'vue';
import axios from "axios";
import {time} from "ionicons/icons"
import RestaurantContent from "@/views/RestaurantView/components/RestaurantContent.vue";

interface Restaurant {
  id: string,
  name: string,
  type: string,
  image: string
}

export default defineComponent({
  name: 'RestaurantView',
  data () {
    return {
      restaurant: {} as Restaurant
    }
  },
  methods: {
    time() {
      return time
    },
    async getRestaurant() {
      const query = 'https://localhost:7012/api/Restaurant/' + this.id;
      const getRestaurantsResponse = await axios.get<Restaurant>(query);
      this.restaurant = getRestaurantsResponse.data;
    },
  },
  async mounted() {
    await this.getRestaurant();
  },
  props: {
    id: String
  },
  components: {
    IonCardContent,
    IonContent,
    IonHeader,
    IonPage,
    IonTitle,
    IonToolbar,
    IonBackButton,
    IonButtons,
    IonCard,
    IonCardHeader,
    IonCardTitle,
    IonCardSubtitle,
    IonLabel,
    IonIcon
  },
});

</script>

<style scoped>
  /*Display the restaurant card in the center center of the page in the middle*/
  ion-card {
    margin: 20px auto;
    height: auto;
    width: 80%;
  }
  #time{
    float: right;
  }
  img{}
</style>
