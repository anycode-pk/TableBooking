<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Bookings</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-grid :fixed="true">
        <ion-row>
          <ion-col>
            <ion-card v-for="(item, index) in items" v-bind:key="index">
              <img alt="Booking" :src="item.img" />
              <ion-card-header>
                <ion-card-title> {{ item.title }}</ion-card-title>
                <ion-card-subtitle> {{ item.subtitle }}</ion-card-subtitle>
                <div class="time">
                  <ion-chip color="success">WAIT TO PICK UP</ion-chip>
                  <ion-chip color="success">
                    <ion-icon :icon="time" size="small" color="primary">
                    </ion-icon>
                    <IonLabel> 8:00-21:00 </IonLabel>
                  </ion-chip>
                </div>
              </ion-card-header>
              <ion-card-content>
                <p>
                  {{ item.desc }}
                </p>
                <ion-button fill="outline" size="medium">Details ❤</ion-button>
              </ion-card-content>
            </ion-card>
          </ion-col>
        </ion-row>
      </ion-grid>
    </ion-content>
  </ion-page>
</template>

<script lang="ts">
import {
  IonPage,
  IonContent,
  IonTitle,
  IonHeader,
  IonToolbar,
  IonList,
  IonCard,
  IonCardContent,
  IonCardHeader,
  IonCardSubtitle,
  IonCardTitle,
  IonCol,
  IonGrid,
  IonRow,
  IonIcon,
  IonLabel,
} from "@ionic/vue";
import { defineComponent } from "vue";

import { time } from "ionicons/icons";

export default defineComponent({
  data() {
    return {
      items: [
        {
          title: "Pizza XXL",
          subtitle: "lorem lorem lorem",
          desc: "lorem lorem lorem",
          img: "https://picsum.photos/700/300?random=3",
        },
        {
          title: "Kebab Rollo",
          subtitle: "lorem lorem lorem",
          desc: "lorem lorem lorem",
          img: "https://picsum.photos/700/300?random=2",
        },
        {
          title: "Wege burger",
          subtitle: "lorem",
          desc: "lorem lorem",
          img: "https://picsum.photos/700/300?random=1",
        },
      ],
    };
  },
  name: "Account",
  components: {
    IonContent,
    IonPage,
    IonTitle,
    IonHeader,
    IonToolbar,
    IonCard,
    IonCardContent,
    IonCardHeader,
    IonCardSubtitle,
    IonCardTitle,
    IonCol,
    IonGrid,
    IonRow,
    IonIcon,
    IonLabel,
  },
  setup() {
    return { time };
  },
});

</script>
<style scoped>
.time {
  margin: 10px 0;
}

ion-button {
  margin: 15px 0px;
  width: 50%;
}
ion-grid {
  display: flex;
  justify-content: center;
}
</style>
