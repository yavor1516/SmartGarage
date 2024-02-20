<template>

    <div class="box">
        <h1>Sign up</h1>
        <div class="in">
            <label for="name">Email address</label>
            <div>
                <input type="text" v-model="username" placeholder="E-mail" /><img v-if="username.length >= 4" src="../assets/ok.svg" alt="">
            </div>
        </div>
        <button class="SignUp" @click="signUp">
            Sign Up
        </button>
        <button class="ToastrTest" @click="tost">
            ToastrTest
        </button>
        <ol></ol>
        <span>You have account? <a href="/login">sign in</a> </span>
    </div>
</template>

<script setup>
    import { toast } from 'vue3-toastify';
    import 'vue3-toastify/dist/index.css';
</script>
<script>

    export default {
        data() {
            return {
                userLoggedIn: false,
                username: ""
            };
        },
        methods: {
            async tost()
            {
                toast.error('failed', { autoClose: 3000 });
            },
            async signUp() {
                try {
                    const response = await fetch('https://smartgarageproject.com/Register', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            Email: this.username // Send the email address
                        })
                    });

                    if (response.ok) {
                        console.log('Sign up successful');
                        toast.success('Email sent successfully', {
                            autoClose: 2000,
                            onOpen: () => {
                                setTimeout(() => {
                                    window.location.href = '/login';
                                }, 2000); // Redirect after 1 second (adjust as needed)
                            }
                        });

                    } else {
                        console.error('Sign up failed:', response.statusText);
                        toast.error('failed', { autoClose: 3000 });
                    }
                } catch (error) {
                    console.error('Error signing up:', error);
                }
            },
          
            changeStep() {
                this.$emit("nextStep", "signinen");
            }
        }
    };
</script>
