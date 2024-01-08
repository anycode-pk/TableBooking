<template>
    <ion-page>
        <ion-content>
            <ion-card>
                <ion-card-header>
                    <ion-card-title>Sign In</ion-card-title>
                </ion-card-header>
                <ion-card-content>
                    <ion-list>
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
                    <ion-button expand="full" @click="signIn">Sign In</ion-button>
                    <a href="account/signup">or sign up</a>
                </ion-footer>
            </ion-card>
        </ion-content>
    </ion-page>
</template>

<script setup lang="ts">
import { IonPage, IonContent, IonCard, IonCardHeader, IonCardTitle, IonCardContent, IonList, IonItem, IonInput, IonFooter, IonButton } from "@ionic/vue";
import { ref, defineEmits } from "vue"
const emit = defineEmits(["switch", "signin"]);
let email = ref("");
let password = ref("");
const signIn = () => {
    console.log("Sign in");
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
