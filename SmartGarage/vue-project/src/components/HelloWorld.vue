<template>
    <div>
        <!-- Header Component -->
        <HeaderComponent />

        <!-- Main Content Section -->
        <section class="hero">
            <div class="container">
                <h2 class="hero-heading">Welcome to Smart Garage - Your Trusted Partner for Automotive Care</h2>
                <p class="hero-text">Your Trusted Partner for Automotive Care</p>
                <router-link to="/dashboard" class="btn btn-primary">Explore Our Services</router-link>
            </div>
        </section>

        <!-- Services Component -->
        <router-view></router-view>

        <!-- About Us Section -->
        <section id="about" class="about">
            <div class="container">
                <h2 class="section-heading">Welcome to Smart Garage - Your Trusted Partner for Automotive Care</h2>
                <!-- Add your about us content here -->
            </div>
        </section>

        <!-- Contact Section -->
        <section id="contact" class="contact">
            <div class="container">
                <h2 class="section-heading">
                    At Smart Garage, we're dedicated to providing you with top-notch automotive services in the most efficient and convenient way possible. Say goodbye to the traditional mechanic garage experience and embrace the future of automotive care with our cutting-edge technology and expert team.

                   

                 
                </h2>
                <!-- Add your contact form or contact details here -->
            </div>
        </section>

        <!-- Footer Component -->
        <FooterComponent />
    </div>
</template>

<script>
    import HeaderComponent from "@/components/HeaderComponent.vue";
    import FooterComponent from "@/components/FooterComponent.vue";

    export default {
        components: {
            HeaderComponent,
            FooterComponent,
        },
    };
</script>

<style>
    /* Add your CSS styling here */
</style>
