<template>
  <ion-page>
    <ion-header>
      <ion-toolbar>
        <ion-title>Account</ion-title>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-router-outlet>
      </ion-router-outlet>
    </ion-content>
  </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonContent, IonTitle, IonHeader, IonToolbar, IonRouterOutlet } from "@ionic/vue";

</script>

<style scoped></style>