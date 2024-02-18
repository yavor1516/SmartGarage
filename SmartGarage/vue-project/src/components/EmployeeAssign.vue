<template>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <div>
        <header>
            <HeaderComponent />
        </header>

        <main>
            <BodyComponent />
            <!-- Your additional content here -->
            <div>
                <!-- Input field with dropdown for Manufacturer -->
                <div class="input-field">
                    <label for="manufacturer">Manufacturer:</label>
                    <ol></ol>
                    <div class="dropdown">
                        <input type="text" id="manufacturer" v-model="selectedManufacturer" @input="filterManufacturers" placeholder="Select or type">
                        <div class="dropdown-content">
                            <div v-for="manufacturer in filteredManufacturers" :key="manufacturer.id" @click="selectManufacturer(manufacturer)">
                                {{ manufacturer.name }}
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Input field with dropdown for Model -->
                <div class="input-field">
                    <label for="model">Model:</label>
                    <ol></ol>
                    <div class="dropdown">
                        <input type="text" id="model" v-model="selectedModel" @input="filterModels" placeholder="Select or type">
                        <div class="dropdown-content">
                            <div v-for="model in filteredModels" :key="model.id" @click="selectModel(model)">
                                {{ model.name }}
                            </div>
                        </div>
                    </div>
                </div>
                <div class="input-field">

                    <label for="model">Employee:</label>
                    <ol></ol>
                    <div class="dropdown">
                        <input type="text" id="model" v-model="selectedModel" @input="filterModels" placeholder="Select or type">
                        <div class="dropdown-content">
                            <div v-for="model in filteredModels" :key="model.id" @click="selectModel(model)">
                                {{ model.name }}
                            </div>
                        </div>
                    </div>
                </div>
                <div class="input-field">

                    <label for="model">Customer:</label>
                    <ol></ol>
                    <div class="dropdown">
                        <input type="text" id="model" v-model="selectedModel" @input="filterModels" placeholder="Select or type">
                        <div class="dropdown-content">
                            <div v-for="model in filteredModels" :key="model.id" @click="selectModel(model)">
                                {{ model.name }}
                            </div>
                        </div>
                    </div>
                </div>

                <div class="input-field">
                    <label for="input4">Registration Plate:</label>
                    <input type="text" id="input4" v-model="input4Value" placeholder="Enter valid Bulgarian registration plate">
                </div>
                <div class="input-field">
                    <label for="input4">Win number:</label>
                    <input type="text" id="input4" v-model="input4Value" placeholder="Enter car Win number">
                </div>
                <ol></ol>
                <button type="button" class="btn btn-primary">Primary</button>
                <!-- Additional input fields here -->
            </div>
            <div class="services">
                <div class="input-field">

                    <label for="model">Services:</label>
                    <ol></ol>
                    <div class="dropdown">
                        <input type="text" id="model" v-model="selectedModel" @input="filterModels" placeholder="Select or type">
                        <div class="dropdown-content">
                            <div v-for="model in filteredModels" :key="model.id" @click="selectModel(model)">
                                {{ model.name }}
                            </div>
                        </div>
                    </div>
                    <table class="table table-hover">
                        <thead>
                            <tr>
                                <th scope="col">#</th>
                                <th scope="col">Service</th>
                                <th scope="col">Employee</th>
                                <th scope="col">Price</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <th scope="row">1</th>
                                <td>Oil change</td>
                                <td>Mike Chobanov</td>
                                <td>200$</td>
                            </tr>
                            <tr>
                                <th scope="row">2</th>
                                <td>Engine filter change</td>
                                <td>Thornton Tristan</td>
                                <td>60$</td>
                            </tr>
                         
                        </tbody>
                    </table>
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
        },
        data() {
            return {
                // Selected manufacturer and model
                selectedManufacturer: "",
                selectedModel: "",
                // Dummy data for manufacturers and models (replace with your actual data)
                manufacturers: [
                    { id: 1, name: "Manufacturer A" },
                    { id: 2, name: "Manufacturer B" },
                    { id: 3, name: "Manufacturer C" }
                ],
                models: [
                    { id: 1, name: "Model X" },
                    { id: 2, name: "Model Y" },
                    { id: 3, name: "Model Z" }
                ]
            };
        },
        computed: {
            filteredManufacturers() {
                return this.manufacturers.filter(manufacturer =>
                    manufacturer.name.toLowerCase().includes(this.selectedManufacturer.toLowerCase())
                );
            },
            filteredModels() {
                return this.models.filter(model =>
                    model.name.toLowerCase().includes(this.selectedModel.toLowerCase())
                );
            }
        },
        methods: {
            filterManufacturers() {
                // Show the dropdown content when typing
                this.$nextTick(() => {
                    document.querySelector("#manufacturer .dropdown-content").style.display = "block";
                });
            },
            filterModels() {
                // Show the dropdown content when typing
                this.$nextTick(() => {
                    document.querySelector("#model .dropdown-content").style.display = "block";
                });
            },
            selectManufacturer(manufacturer) {
                this.selectedManufacturer = manufacturer.name;
                // Hide the dropdown content after selecting an option
                document.querySelector("#manufacturer .dropdown-content").style.display = "none";
            },
            selectModel(model) {
                this.selectedModel = model.name;
                // Hide the dropdown content after selecting an option
                document.querySelector("#model .dropdown-content").style.display = "none";
            }
        }
    };
</script>

<style scoped>
    .services{
        position:absolute;
        right:40vh;
        width:600px;
        top:12%;
    }

    label {
        font-weight: bold;
    }

    input {
        width: calc(100% - 40px); /* Adjust the width of the input field */
        padding: 8px;
        border: 1px solid #ccc;
        border-radius: 4px;
        box-sizing: border-box;
        color:black;
    }

    .dropdown {
        position: relative;
        display: inline-block;
    }

    .dropdown-content {
        display: none;
        position: absolute;
        background-color: #f9f9f9;
        color:black;
        min-width: 100%;
        z-index: 1;
        border: 1px solid #ddd;
        border-radius: 4px;
        overflow-y: auto;
        max-height: 150px; /* Adjust the max height of the dropdown menu */
    }

        .dropdown-content div {
            padding: 8px;
            cursor: pointer;
        }

    .dropdown:hover .dropdown-content {
        display: block;
    }
</style>
