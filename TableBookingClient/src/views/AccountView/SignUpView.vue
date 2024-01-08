<template>
    <ion-page>
        <ion-content>
            <ion-card>
                <ion-card-header>
                    <ion-card-title>Sign Up</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                    <ion-list>
                        <ion-item>
                            <ion-input label="Name" label-placement="floating" v-model="name" type="text"></ion-input>
                        </ion-item>
                        <ion-item>
                            <ion-input label="Email" label-placement="floating" v-model="email" type="email"></ion-input>
                        </ion-item>
                        <ion-item>
                            <ion-input label="Password" label-placement="floating" v-model="password"
                                type="password"></ion-input>
                        </ion-item>
                    </ion-list>
                </ion-card-content>
                <ion-footer>
                    <ion-button expand="full" @click="signUp">Sign Up</ion-button>
                    <a href="account/signin">back</a>
                </ion-footer>
            </ion-card>
        </ion-content>
    </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonContent, IonCard, IonCardHeader, IonCardTitle, IonCardContent, IonList, IonItem, IonInput, IonFooter, IonButton } from "@ionic/vue";
import { ref } from "vue";
let name = ref("");
let email = ref("");
let password = ref("");
const signUp = () => {
    console.log("Sign Up");
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
