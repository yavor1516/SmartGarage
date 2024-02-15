<template>

    <signinen></signinen>





</template>

<script>
    import signinen from "@/components/sign-up-en.vue";
    export default {
        name: "About",
        components: {
            signinen
        },
    };
</script>

<style>
    .box {
        position: fixed;
        /* Align the element to the right border */
        right: 0;
        top: 20vh;
        transform: scale(2);
        transform-origin: top right;
    }
</style>