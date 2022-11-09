<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-back-button default-href="/tabs/home"></ion-back-button>
        </ion-buttons>
        <ion-title>Admin</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-list>
        <IonCard>
          <ion-card-header color="success">
            <ion-card-title>
              Create restaurant
            </ion-card-title>
          </ion-card-header>
          <ion-item>
            <ion-input v-model="restaurant.name" placeholder="name"></ion-input>
          </ion-item>
          <ion-item>
            <ion-input v-model="restaurant.type" placeholder="type"></ion-input>
          </ion-item>
          <ion-item>
            <ion-input v-model="restaurant.image" placeholder="image"></ion-input>
          </ion-item>
          <ion-item>
            <IonButton color="success" slot="end" @click="postRestaurant()">Create</IonButton>
          </ion-item>
        </IonCard>
        <ion-card>
          <ion-card-header color="primary">
            <ion-card-title>
              Edit restaurants
            </ion-card-title>
          </ion-card-header>
          <ion-toolbar>
            <ion-buttons slot="end">
              <ion-button @click="getRestaurants" fill="solid" color="medium">
                Fetch
              </ion-button>
            </ion-buttons>
            <ion-searchbar @ionChange="handleChange($event)"></ion-searchbar>
          </ion-toolbar>

          <ion-list>
              <ion-list v-for="restaurant in results" :key="restaurant.id">
                <ion-item>
                  <ion-toolbar>
                    {{restaurant.name}}
                    <ion-buttons slot="end">
                      <ion-button color="warning" :id="restaurant.id">Edit</ion-button>
                      <ion-button color="danger">
                        delete
                      </ion-button>
                    </ion-buttons>
                  </ion-toolbar>
                </ion-item>
                <ion-popover :trigger="restaurant.id" trigger-action="click">
                  <ion-card>
                    <ion-list>
                      <ion-item>
                        <ion-label>name:</ion-label>
                        <ion-input v-model="restaurant.name" placeholder="type"></ion-input>
                      </ion-item>
                      <ion-item>
                        <ion-label>type:</ion-label>
                        <ion-input v-model="restaurant.type" placeholder="type"></ion-input>
                      </ion-item>
                      <ion-item>
                        <ion-label>image src:</ion-label>
                        <ion-input v-model="restaurant.image" placeholder="image"></ion-input>
                      </ion-item>
                      <ion-item>
                        <IonButton color="warning" slot="end" >Update</IonButton>
                      </ion-item>
                    </ion-list>
                  </ion-card>
                </ion-popover>
              </ion-list>
          </ion-list>
        </ion-card>
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonBackButton,
  IonButton, IonButtons, IonCard, IonCardHeader, IonCardTitle,
  IonContent,
  IonHeader,
  IonInput,
  IonItem, IonLabel,
  IonList,
  IonPage, IonPopover, IonSearchbar,
  IonTitle,
  IonToolbar, toastController
} from '@ionic/vue';
import {defineComponent, ref} from 'vue';
import axios from "axios";

interface Restaurant {
  id: string,
  name: string,
  type: string,
  image: string
}

export default defineComponent({
  name: 'AdminView',
  data () {
    return{
      restaurant: {} as Restaurant,
      restaurants: [] as Restaurant[]
    }
  },
  setup(){
    const results = ref({});
    return { results }
  },
  methods: {
    handleChange(event) {
      const query = event.target.value.toLowerCase();
      this.results = this.restaurants.filter(d => d.name.toLowerCase().indexOf(query) > -1);
    },
    async postRestaurant(){
      axios.post("https://localhost:7012/api/Restaurant", this.restaurant).then((response) => {this.presentToast(response.status)});
    },
    async deleteRestaurant(id: string){
      axios.delete("https://localhost:7012/api/Restaurant/"+id).then((response) => {this.presentToast(response.status)});
    },
    async getRestaurants() {
      const getRestaurantsResponse = await axios.get<Restaurant[]>('https://localhost:7012/api/Restaurant')
      this.restaurants = getRestaurantsResponse.data
      this.results = this.restaurants;
    },
    async presentToast(response: number) {
      let message = "Status: " + response.toString() + ((response>=200 && response<300)?" Success":" Error");
      const toast = await toastController.create({
        message: message,
        duration: 4000,
        position: 'bottom'
      });
      await toast.present();
    },
  },
  components: {
    IonContent,
    IonHeader,
    IonPage,
    IonTitle,
    IonToolbar,
    IonList,
    IonItem,
    IonButton,
    IonInput,
    IonCard,
    IonCardHeader,
    IonCardTitle,
    IonBackButton,
    IonButtons,
    IonPopover,
    IonSearchbar,
    IonLabel
  },
});

</script>

<style scoped>

</style>
