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
        <ion-radio-group v-model="selectedSort">
          <ion-list-header>
            <ion-label>Sort</ion-label>
          </ion-list-header>
          <ion-item>
            <ion-icon :icon="flameSharp" />
            <ion-radio slot="end" color="success" v-model="sortingMethod.popular">Popular</ion-radio>
          </ion-item>
          <ion-item>
            <ion-icon :icon="starSharp" />
            <ion-radio slot="end" color="success" v-model="sortingMethod.rating">Rating</ion-radio>
          </ion-item>
          <ion-item>
            <ion-icon :icon="locationSharp" />
            <ion-radio slot="end" color="success" v-model="sortingMethod.distance">Distance</ion-radio>
          </ion-item>
        </ion-radio-group>
        <ion-radio-group v-model="selectedPrice">
          <ion-list-header>
            <ion-label>Price</ion-label>
          </ion-list-header>
          <ion-item>
            <ion-radio slot="end" color="success" v-model="priceRange.$">$</ion-radio>
          </ion-item>
          <ion-item>
            <ion-radio slot="end" color="success" v-model="priceRange.$$">$$</ion-radio>
          </ion-item>
          <ion-item>
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
import { optionsSharp, arrowBackSharp, checkmarkSharp, flameSharp, starSharp, locationSharp } from 'ionicons/icons';
import { OverlayEventDetail } from '@ionic/core';
import { priceRange, sortingMethod } from '@/models';

const modal = ref<typeof IonModal | null>(null);

const selectedPrice = ref<priceRange>(priceRange.$);
const selectedSort = ref<sortingMethod>(sortingMethod.popular);

const emit = defineEmits(['update:price', 'update:sort']);

const changePrice = () => {
  emit('update:price', selectedPrice);
};

const changeSort = () => {
  emit('update:sort', selectedSort);
};

const cancel = () => {
  modal.value?.$el.dismiss(null, 'cancel');
};

const confirm = () => {
  changePrice();
  changeSort();
  console.log("updated filters\nprice: " + selectedPrice.value + "\nsort: " + selectedSort.value + "\n");
  modal.value?.$el.dismiss(null, 'confirm');
};

const onWillDismiss = (ev: CustomEvent<OverlayEventDetail>) => {
  if (ev.detail.role === 'confirm') {
    // On confirm
  }
  if (ev.detail.role === 'cancel') {
    // On cancel
  }
};
</script>
