<template>
    <div class="hello">
        <h1>Vehicles:</h1>
        <button @click="fetchData">Click Me!</button>
        <p v-if="fact">{{ fact }}</p>
    </div>
</template>

<script setup>
    import { toast } from 'vue3-toastify';
    import 'vue3-toastify/dist/index.css';
</script>

<script>
    export default {
        props: {
            msg: String,
        },
        data() {
            return {
                fact: "",
            };
        },
        methods: {
            fetchData() {
                fetch('https://localhost:7156/Vehicles', {
                    method: "GET"
                })
                    .then((response) => {
                        response.json().then((data) => {

                            this.fact = data.vehicleBrand + " " + data.vehicleModel;
                            toast.success(this.fact, { autoClose: 3000 });
                        });

                    })
                    .catch((err) => {
                        console.error(err);
                    });
            },
        },

    };
</script>

<style>
    button {
        padding: 12px 32px;
        font-size: 16px;
        border-radius: 8px;
    }
</style>




<style scoped>
    h1 {
        font-weight: 500;
        font-size: 2.6rem;
        position: relative;
        top: -10px;
    }

    h3 {
        font-size: 1.2rem;
    }

    .greetings h1,
    .greetings h3 {
        text-align: center;
    }

    @media (min-width: 1024px) {
        .greetings h1,
        .greetings h3 {
            text-align: left;
        }
    }
</style>
