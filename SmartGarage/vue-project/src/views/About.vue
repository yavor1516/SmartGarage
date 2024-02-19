<script setup>

    import TheWelcome from '../components/ImageSlideShow.vue'
    import('https://static.elfsight.com/platform/platform.js')
        .then(() => {
            // Script loaded successfully
        })
        .catch(error => {
            // Error handling
            console.error('Error loading script:', error);
        });
</script>

<template>
    <main>
        <TheWelcome />
    </main>
</template>
