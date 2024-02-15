<template>
    <div>
        <header>
            <HeaderComponent />
        </header>

        <main>
            <BodyComponent />
        </main>

        <footer>
            <FooterComponent />
        </footer>
    </div>
</template>

<script>
    import HeaderComponent from "@/components/HeaderComponent.vue";
    import BodyComponent from "@/components/BodyComponent.vue";
    import FooterComponent from "@/components/FooterComponent.vue";

    export default {
        components: {
            HeaderComponent,
            BodyComponent,
            FooterComponent
        }
    }
</script>