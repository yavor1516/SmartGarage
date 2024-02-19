<template>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    <div>
        <header>
            <HeaderComponent />
        </header>

        <main>
            <BodyComponent />
            <div class="LinkedVehicleAssignment">
                <!-- Button to toggle visibility -->
                <button type="button" class="btn btn-primary" @click="listOfCars">List of all cars</button>

                <ol></ol>
                <button type="button" class="btn btn-primary" @click="toggleAssignVehicle">Create new car</button>

            </div>

            <!-- Your additional content here -->
            <div class="AssignVehicle" v-if="showAssignVehicle">


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
                    <button type="button" class="btn btn-success" @click="assignVehicle">Assign</button>
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
                                    <th scope="col">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Oil change</td>
                                    <td>Mike Chobanov</td>
                                    <td>200$</td>


                                    <td>
                                        <button type="button" class="btn btn-primary" @click="">Delete</button>
                                    </td>
                                </tr>
                                <tr>
                                    <th scope="row">2</th>
                                    <td>Engine filter change</td>
                                    <td>Thornton Tristan</td>
                                    <td>60$</td>

                                    <td>
                                        <button type="button" class="btn btn-primary" @click="">Delete</button>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="ListOfCars" v-if="carList">
                <div class="Vehicles">
                    <div class="input-field">

                        <label for="model">Vehicles:</label>
                        <ol></ol>
                        <div class="dropdown">
                            <input type="text" id="model" v-model="selectedModel" @input="filterModels" placeholder="Select or search">
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
                                    <th scope="col">Car</th>
                                    <th scope="col">Customer</th>
                                    <th scope="col">Progress</th>
                                    <th scope="col">Employee</th>
                                    <th scope="col">Price</th>
                                    <th scope="col">Edit</th>
                                    <th scope="col">Delete</th>

                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Toyota Corola</td>
                                    <td>Mike Chobanov</td>
                                    <td>50%</td>
                                    <td>Stephan Tomson</td>
                                    <td>200$</td>
                                    <td>
                                        <button type="button" class="btn btn-primary" @click="">Edit</button>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-primary" @click="">Delete</button>
                                    </td>


                                </tr>
                                <tr>
                                    <th scope="row">1</th>
                                    <td>Bmw X5</td>
                                    <td>Stephan Chobanov</td>
                                    <td>100%</td>
                                    <td>Stephan Tomson</td>
                                    <td>2000$</td>
                                    <td>
                                        <button type="button" class="btn btn-primary" @click="">Edit</button>
                                    </td>
                                    <td>
                                        <button type="button" class="btn btn-primary" @click="">Delete</button>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                    <nav aria-label="Page navigation example">
                        <ul class="pagination">
                            <li class="page-item"><a class="page-link" href="#">Previous</a></li>
                            <li class="page-item"><a class="page-link" href="#">1</a></li>
                            <li class="page-item"><a class="page-link" href="#">2</a></li>
                            <li class="page-item"><a class="page-link" href="#">3</a></li>
                            <li class="page-item"><a class="page-link" href="#">Next</a></li>
                        </ul>
                    </nav>
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
                ],
                showAssignVehicle: false,
                carList:true
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
            toggleAssignVehicle() {
              
                this.showAssignVehicle = !this.showAssignVehicle;
                if (this.showAssignVehicle && this.carList) {
                    this.carList = !this.carList;
                }
              

            },
            listOfCars() {
               
                this.carList = !this.carList;  
                if (this.carList && this.showAssignVehicle) {
                    this.showAssignVehicle = !this.showAssignVehicle;
                }
               

            },
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
    .ListOfCars{
          left: 23.5%;
        top: 12%;
        position: absolute;
    }
    .LinkedVehicleAssignment {
        left: 5%;
        top: 15%;
        position: absolute;
    }
    .services {
        position: absolute;
        right: 20vh;
        width: 600px;
        top: 12%;
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
