<template>
    <div>
        <header>
            <HeaderComponent />
        </header>

        <main>
            <BodyComponent />
            <!-- Your additional content here -->
            <div class="lecture px-10 flex flex-row max-sm:flex-col">
                <div>
                    <h1 class="mb-6 pt-16 text-3xl text-white">Find University archive's here</h1>
                    <p class="text-neutral-500">
                        The College Study Discord Server is a vibrant community where students from various majors gather to study, collaborate, and share knowledge. Join our community and let's support each other in our academic journeys.
                    </p>
                    <div class="pt-5">
                        <NuxtLink to="https://discord.gg/5zfQQYvH" class="inline-block py-2 px-2 bg-lime-400 text-gray-800 rounded-md">Join Discord</NuxtLink>
                    </div>
                </div>
                <div class="pl-60 pr-32 max-sm:pr-11 max-sm:pl-0">
                    <svg xmlns="http://www.w3.org/2000/svg" data-name="Layer 1" width="300" height="400" viewBox="0 0 987.58708 714.02784" xmlns:xlink="http://www.w3.org/1999/xlink">
                        <!-- Your SVG content -->
                    </svg>
                </div>
            </div>
            <!-- End of additional content -->
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