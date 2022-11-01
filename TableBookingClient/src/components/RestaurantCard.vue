<template>
  <ion-card>
    <img src={{image}} />
    <ion-toolbar>
      <ion-buttons slot="primary">
        <ion-button fill="clear">
          <ion-icon slot="icon-only" :icon=heartSharp />
        </ion-button>
        <ion-button fill="clear">
          <ion-icon slot="icon-only" :icon=shareSharp />
        </ion-button>
      </ion-buttons>
      <ion-card-header>
        <ion-card-title>{{ name || 'Name' }}</ion-card-title>
        <ion-card-subtitle>{{ type || 'Type' }}</ion-card-subtitle>
      </ion-card-header>
    </ion-toolbar>
  </ion-card>
</template>

<script setup lang="ts">
  import { IonCard, IonToolbar, IonButtons, IonIcon, IonButton, IonCardHeader, IonCardTitle, IonCardSubtitle } from "@ionic/vue";
  import {defineProps} from "vue"
  import { shareSharp, heartSharp } from "ionicons/icons";
  const props = defineProps({
    name: String,
    type: String,
    image: String
  })
</script>

<style>

</style>