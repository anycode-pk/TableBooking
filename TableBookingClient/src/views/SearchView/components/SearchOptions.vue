<template>
  <ion-buttons slot="end">
    <ion-button id="open-modal" expand="block">
      <ion-icon slot="icon-only" :icon="optionsSharp"></ion-icon>
    </ion-button>
  </ion-buttons>
  <ion-modal ref="modal" trigger="open-modal" @willDismiss="onWillDismiss">
    <ion-header>
      <ion-toolbar>
        <ion-buttons slot="start">
          <ion-button @click="cancel()">
            <ion-icon slot="icon-only" :icon="arrowBackSharp" />
          </ion-button>
        </ion-buttons>
        <ion-title>Filters</ion-title>
        <ion-buttons slot="end">
          <ion-button @click="confirm()">
            <ion-icon slot="icon-only" :icon="checkmarkSharp" />
          </ion-button>
        </ion-buttons>
      </ion-toolbar>
    </ion-header>
    <ion-content>
      <ion-list>
        <ion-radio-group v-model="searchOptions.sort">
          <ion-list-header>
            <ion-label>Sort</ion-label>
          </ion-list-header>
          <ion-item>
            <ion-icon slot="start" :icon="flameSharp" />
            <ion-radio slot="end" color="success" v-model="sortingMethod.popular">Popular</ion-radio>
          </ion-item>
          <ion-item>
            <ion-icon slot="start" :icon="starSharp" />
            <ion-radio slot="end" color="success" v-model="sortingMethod.rating">Rating</ion-radio>
          </ion-item>
          <ion-item>
            <ion-icon slot="start" :icon="locationSharp" />
            <ion-radio slot="end" color="success" v-model="sortingMethod.distance">Distance</ion-radio>
          </ion-item>
        </ion-radio-group>
        <ion-radio-group v-model="searchOptions.price">
          <ion-list-header>

            <ion-label>Price</ion-label>
          </ion-list-header>
          <ion-item>
            <ion-icon slot="start" :icon="logoUsd" />
            <ion-radio slot="end" color="success" v-model="priceRange.$">$</ion-radio>
          </ion-item>
          <ion-item>
            <ion-icon slot="start" :icon="logoUsd" />
            <ion-radio slot="end" color="success" v-model="priceRange.$$">$$</ion-radio>
          </ion-item>
          <ion-item>
            <ion-icon slot="start" :icon="logoUsd" />
            <ion-radio slot="end" color="success" v-model="priceRange.$$$">$$$</ion-radio>
          </ion-item>
        </ion-radio-group>
      </ion-list>
    </ion-content>
  </ion-modal>
</template>

<script setup lang="ts">
import { ref, defineEmits } from 'vue';
import { IonModal, IonIcon, IonContent, IonList, IonRadioGroup, IonItem, IonRadio, IonListHeader, IonLabel, IonHeader, IonToolbar, IonButtons, IonButton, IonTitle } from '@ionic/vue';
import { optionsSharp, arrowBackSharp, checkmarkSharp, flameSharp, starSharp, locationSharp, logoUsd } from 'ionicons/icons';
import { OverlayEventDetail } from '@ionic/core';
import { priceRange, sortingMethod, SearchOptions } from '@/models';

const searchOptions = ref<SearchOptions>({
  price: priceRange.$,
  sort: sortingMethod.popular,
  query: ''
});

const emit = defineEmits(['options-updated']);

const modal = ref<typeof IonModal | null>(null);
const cancel = () => {
  modal.value?.$el.dismiss(null, 'cancel');
};
const confirm = () => {
  modal.value?.$el.dismiss(null, 'confirm');
};
const onWillDismiss = (ev: CustomEvent<OverlayEventDetail>) => {
  if (ev.detail.role === 'confirm') {
    emit('options-updated', searchOptions.value);
  }
  if (ev.detail.role === 'cancel') {
    // Cancel
  }
};
</script>
