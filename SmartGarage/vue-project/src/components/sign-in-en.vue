<template>
    <div class="box">
        <h1>Sign in</h1>

        <div class="in">
            <label for="name">Email address</label>
            <div>
                <input type="text" v-model="username" placeholder="E-mail" /><img v-if="username.length >= 4" src="../assets/ok.svg" alt="">
            </div>
        </div>

        <div class="in">
            <label for="name">Password</label>
            <div>
                <input v-model="password" type="password" :name="string" placeholder="8 caractere minimum" required /><img v-if="password.length >= 8" src="../assets/ok.svg" alt="">
            </div>
        </div>

        <div class="password_bar">
            <div :class="{'bar':true, 'green':(password.length > 1)}"></div>
            <div :class="{'bar':true, 'green':(password.length > 3)}"></div>
            <div :class="{'bar':true, 'green':(password.length > 5)}"></div>
            <div :class="{'bar':true, 'green':(password.length > 7)}"></div>
        </div>

        <div class="check_bar">
            <div>
                <input type="checkbox" name="" id="">
                <label for="">Remember me</label>
            </div>
            <a href="">Forgotten password? </a>
        </div>

        <button class="Login" @click="signIn">
            Login
        </button>
        <ol></ol>
        <span>You dont have account? <a href="/signup">Sing up</a> </span>
    </div>
    <img alt="car logo" class="car" src="@/assets/Images/Car.png" width="125" height="125" />

</template>
<script setup>
    import { toast } from 'vue3-toastify';
    import 'vue3-toastify/dist/index.css';
    import { useStore } from 'vuex';

    const store = useStore(); // Access the store directly within setup
</script>
<script>
    export default {
        data() {
            return {
                password: "",
                userLoggedIn: false,
                username: ""
            };
        },
        methods: {
            async signIn() {
                try {
                    const response = await fetch('https://backend.smartgarageproject.com/Login', {
                        method: 'POST',
                        headers: {
                            'Content-Type': 'application/json'
                        },
                        body: JSON.stringify({
                            Email: this.username,
                            Password: this.password
                        })
                    });

                    if (response.ok) {
                        console.log('Sign in successful');
                        const data = await response.json();
                        localStorage.setItem("JwtAcessToken", 'Bearer ' + data.accessToken)
                      
                        window.location.href = '/';
                        // Redirect to another page or perform other actions
                    } else {
                        console.error('Sign in failed:', response.statusText);
                        toast.error('wrong password', { autoClose: 3000 });
                        // Handle failed sign in
                    }
                } catch (error) {
                    console.error('Error signing in:', error);
                    toast.error('something wrong', { autoClose: 3000 });

                    // Handle error
                }
            },
            changeStep() {
                this.$emit("nextStep", "signinen");
            }
        }
    };
</script>
