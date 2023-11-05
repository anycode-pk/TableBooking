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
        <ion-radio-group value="popular">
          <ion-list-header>
            <ion-label>Sort</ion-label>
          </ion-list-header>
          <ion-item>
            <ion-icon :icon="flameSharp" />
            <ion-label>Popular</ion-label>
            <ion-radio slot="end" color="success" value="popular" mode="ios"></ion-radio>
          </ion-item>

          <ion-item>
            <ion-icon :icon="starSharp" />
            <ion-label>Rating</ion-label>
            <ion-radio slot="end" color="success" value="rating" mode="ios"></ion-radio>
          </ion-item>

          <ion-item>
            <ion-icon :icon="locationSharp" />
            <ion-label>Distance</ion-label>
            <ion-radio slot="end" color="success" value="time" mode="ios"></ion-radio>
          </ion-item>
        </ion-radio-group>
        <ion-radio-group value="1">
          <ion-list-header>
            <ion-label>Price</ion-label>
          </ion-list-header>
          <ion-item>
            <ion-label>$</ion-label>
            <ion-checkbox slot="end" checked='checked'></ion-checkbox>
          </ion-item>
          <ion-item>
            <ion-label>$$</ion-label>
            <ion-checkbox slot="end" checked='checked'></ion-checkbox>
          </ion-item>
          <ion-item>
            <ion-label>$$$</ion-label>
            <ion-checkbox slot="end" checked='checked'></ion-checkbox>
          </ion-item>
        </ion-radio-group>
      </ion-list>
    </ion-content>
  </ion-modal>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { IonModal, IonIcon } from '@ionic/vue';
import { optionsSharp, arrowBackSharp, checkmarkSharp, flameSharp, starSharp, locationSharp } from 'ionicons/icons';
import { OverlayEventDetail } from '@ionic/core';

const modal = ref<typeof IonModal | null>(null);

const openModal = () => {
  modal.value = modal.value?.$el.present();
};

const cancel = () => {
  modal.value?.$el.dismiss(null, 'cancel');
};

const confirm = () => {
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
