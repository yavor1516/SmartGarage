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


        <button class="log">
            Login
        </button>


        <span>You dont have account? <a href="/signup">Sing up</a> </span>
    </div>

</template>


<script>
    export default {
      data() {
        return {
          password:"",
          userLoggedIn: false,
          username:""
        };

      },
      method: {
   changeStep(){
              this.$emit("nextStep", "signinen");
   }
    }
    };

</script>




