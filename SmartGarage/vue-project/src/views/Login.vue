<template>

    <signinen></signinen>





</template>


<script>
    import signinen from "@/components/sign-in-en.vue";
    export default {
        name: "About",
        components: {
            signinen
        },
    };
</script>

<style>
    .box {
        position: absolute;
        /* Align the element to the right border */
       
        top: 20vh;
        left:10%;
        transform: scale(2);
        transform-origin: top left;
    }
  
   

</style>