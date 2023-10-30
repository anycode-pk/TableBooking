<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Home</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <!-- content -->
      <ion-list>
        <ion-list-header>
          <ion-label>Hello, name! You're last orders: </ion-label>
        </ion-list-header>
        <ion-item>
          <ion-label>McDonald, Zwycięstwa 22 Koszalin</ion-label>
        </ion-item>
        <ion-item>
          <ion-label>KFC, Ogrodowa 23 </ion-label>
        </ion-item>
        <ion-item>
          <ion-label>Krowa Burger, Traugutta 22 Mielno</ion-label>
        </ion-item>
        <ion-item>
          <ion-label>Fregata, Warszawa 23/4</ion-label>
        </ion-item>
        <ion-item>
          <ion-label>Mr Krycha, Kraków 22</ion-label>
        </ion-item>
      </ion-list>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import {IonContent, IonHeader, IonIcon, IonPage, IonTitle, IonToolbar} from '@ionic/vue';
import { calendarSharp, personSharp, searchSharp, homeSharp } from 'ionicons/icons';

</script>

<style scoped>
ion-item{
  margin-left: 20px;
}
ion-label
{
  font-size: 1.5em !important;
}
</style>