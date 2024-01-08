<template>
    <ion-page>
        <ion-content>
            <ion-card>
                <ion-card-header>
                    <ion-card-title>{{ username }}</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                    <ion-list>
                        <ion-item>
                            <p>Lorem ipsum</p>
                        </ion-item>
                        <ion-item>
                            <p>Lorem ipsum</p>
                        </ion-item>
                    </ion-list>
                </ion-card-content>
                <ion-footer>
                    <ion-button expand="full" @click="signOut">Sign Out</ion-button>
                </ion-footer>
            </ion-card>
        </ion-content>
    </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonContent, IonCard, IonCardHeader, IonCardTitle, IonCardContent, IonList, IonItem, IonInput, IonFooter, IonButton } from "@ionic/vue";
import { ref } from "vue"
let username = ref("John Doe");

const signOut = () => {
    console.log("Sign out");
};
</script>

<style scoped>
a {
    text-align: center;
    display: block;
    margin-top: 10px;
    margin-bottom: 10px;
}
</style>
