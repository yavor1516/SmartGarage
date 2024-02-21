<template>
    <div>
        <!-- Header Component -->
        <HeaderComponent />

        <!-- Main Content Section -->
        <section class="about-section">
            <div class="container">
                <div class="row">
                    <div class="col-md-6">
                        <h2 class="section-heading">About Smart Garage</h2>
                        <p class="about-text">
                            Smart Garage is a premier automotive care center dedicated to providing top-notch services to our customers. With years of experience in the industry, our team of skilled technicians is committed to delivering exceptional results and ensuring the satisfaction of every client.
                        </p>
                        <p class="about-text">
                            Our state-of-the-art facility is equipped with the latest tools and technology to handle a wide range of automotive issues. Whether you need routine maintenance, repairs, or custom modifications, you can trust Smart Garage to get the job done right.
                        </p>
                        <router-link to="/contact" class="btn btn-primary">Contact Us</router-link>
                    </div>
                    <div class="col-md-6">
               
                    </div>
                </div>
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
    .about-section {
        padding: 80px 0;
    }

    .section-heading {
        font-size: 36px;
        font-weight: bold;
        color: #333;
        margin-bottom: 30px;
    }

    .about-text {
        font-size: 18px;
        line-height: 1.6;
        margin-bottom: 20px;
    }

    .about-image {
        border-radius: 10px;
    }
</style>
