<template>
    <div>
        <!-- Header and Body Components -->
        <header>
            <HeaderComponent />
        </header>
        <main>
            <BodyComponent />

            <div class="container">
                <div class="main-body">
                    <!-- Breadcrumb -->
                    <!-- /Breadcrumb -->
                    <div class="row gutters-sm">
                        <div class="col-md-4 mb-3">
                            <!-- Profile card -->
                            <div class="card">
                                <!-- Card body -->
                                <div class="card-body">
                                    <!-- Profile information -->
                                    <div class="d-flex flex-column align-items-center text-center">
                                        <img src="https://bootdey.com/img/Content/avatar/avatar7.png" alt="Admin" class="rounded-circle" width="150">
                                        <div class="mt-3">
                                            <h4>John Doe</h4>
                                            <p class="text-secondary mb-1">Full Stack Developer</p>
                                            <p class="text-muted font-size-sm">Bay Area, San Francisco, CA</p>
                                            <button class="btn btn-primary" @click="toggleCardVisibility">{{ isCardVisible ? 'Show Cars Information' : 'Show Profile Information' }}</button>

                                        </div>
                                    </div>
                                    <!-- End of Profile information -->
                                </div>
                                <!-- End of Card body -->
                            </div>
                            <!-- End of Profile card -->
                            <!-- List group -->
                            <div class="card mt-3">
                                <ul class="list-group list-group-flush">
                                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                        <h6 class="mb-0"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 512 512"><!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.--><path d="M164.9 24.6c-7.7-18.6-28-28.5-47.4-23.2l-88 24C12.1 30.2 0 46 0 64C0 311.4 200.6 512 448 512c18 0 33.8-12.1 38.6-29.5l24-88c5.3-19.4-4.6-39.7-23.2-47.4l-96-40c-16.3-6.8-35.2-2.1-46.3 11.6L304.7 368C234.3 334.7 177.3 277.7 144 207.3L193.3 167c13.7-11.2 18.4-30 11.6-46.3l-40-96z" /></svg> Phone number</h6>
                                        <span class="text-secondary">+359877344349</span>
                                    </li>
                                    <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                        <h6 class="mb-0"><svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 512 512"><!--!Font Awesome Free 6.5.1 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2024 Fonticons, Inc.--><path d="M48 64C21.5 64 0 85.5 0 112c0 15.1 7.1 29.3 19.2 38.4L236.8 313.6c11.4 8.5 27 8.5 38.4 0L492.8 150.4c12.1-9.1 19.2-23.3 19.2-38.4c0-26.5-21.5-48-48-48H48zM0 176V384c0 35.3 28.7 64 64 64H448c35.3 0 64-28.7 64-64V176L294.4 339.2c-22.8 17.1-54 17.1-76.8 0L0 176z" /></svg> Email</h6>
                                        <span class="text-secondary">milen316@gmail.com</span>
                                    </li>
                                </ul>
                            </div>
                            <!-- End of List group -->
                        </div>
                        <!-- Toggle button for card visibility -->
                        <div class="col-md-8">
                            <!-- Profile information card -->
                            <div class="card mb-3" v-if="isCardVisible">
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Full Name</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary">
                                            Kenneth Valdez
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Email</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary">
                                            fip@jukmuh.al
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Phone</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary">
                                            (239) 816-9029
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Mobile</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary">
                                            (320) 380-4539
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-3">
                                            <h6 class="mb-0">Address</h6>
                                        </div>
                                        <div class="col-sm-9 text-secondary">
                                            Bay Area, San Francisco, CA
                                        </div>
                                    </div>
                                    <hr>
                                    <div class="row">
                                        <div class="col-sm-12">
                                            <a class="btn btn-info" target="__blank" href="https://www.bootdey.com/snippets/view/profile-edit-data-and-skills">Edit</a>
                                        </div>
                                    </div>
                                </div>
                                <div class="cardEdit" v-if="!isCardEditVisible">
                                    <div class="card-body">
                                        <div class="row mb-3">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Full Name</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary">
                                                <input type="text" class="form-control" value="John Doe">
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Email</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary">
                                                <input type="text" class="form-control" value="john@example.com">
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Phone</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary">
                                                <input type="text" class="form-control" value="(239) 816-9029">
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Mobile</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary">
                                                <input type="text" class="form-control" value="(320) 380-4539">
                                            </div>
                                        </div>
                                        <div class="row mb-3">
                                            <div class="col-sm-3">
                                                <h6 class="mb-0">Address</h6>
                                            </div>
                                            <div class="col-sm-9 text-secondary">
                                                <input type="text" class="form-control" value="Bay Area, San Francisco, CA">
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-3"></div>
                                            <div class="col-sm-9 text-secondary">
                                                <input type="button" class="btn btn-primary px-4" value="Save Changes">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- End of Profile information card -->
                            <div class="Table" v-if="!isCardVisible">
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th scope="col">#</th>
                                            <th scope="col">Car</th>
                                            <th scope="col">Progress</th>
                                            <th scope="col">Price</th>
                                            <th scope="col">Info</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <th scope="row">1</th>
                                            <td>Bmw E46 328 ci</td>
                                            <td>50%</td>
                                            <td>500$</td>
                                            <td>
                                                <button type="button" class="btn btn-primary" @click="">Show</button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">2</th>
                                            <td>Mercedes E320 2010</td>
                                            <td>90%</td>
                                            <td>2000$</td>
                                            <td>
                                                <button type="button" class="btn btn-primary" @click="">Show</button>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th scope="row">3</th>
                                            <td>Audi RS6 3.0 D</td>
                                            <td>20%</td>
                                            <td>12000$</td>
                                            <td>
                                                <button type="button" class="btn btn-primary" @click="">Show</button>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <nav aria-label="Page navigation example">
                                    <ul class="pagination">
                                        <li class="page-item">
                                            <a class="page-link" href="#" aria-label="Previous">
                                                <span aria-hidden="true">&laquo;</span>
                                                <span class="sr-only">Previous</span>
                                            </a>
                                        </li>
                                        <li class="page-item"><a class="page-link" href="#">1</a></li>
                                        <li class="page-item"><a class="page-link" href="#">2</a></li>
                                        <li class="page-item"><a class="page-link" href="#">3</a></li>
                                        <li class="page-item">
                                            <a class="page-link" href="#" aria-label="Next">
                                                <span aria-hidden="true">&raquo;</span>
                                                <span class="sr-only">Next</span>
                                            </a>
                                        </li>
                                    </ul>
                                </nav>
                            </div>
                        </div>


                    </div>


                </div>
            </div>
        </main>
        <!-- Footer Component -->
        <footer>
            <FooterComponent />
        </footer>
    </div>
</template>

<script>
    import 'bootstrap/dist/css/bootstrap.min.css';
    import HeaderComponent from "@/components/HeaderComponent.vue";
    import BodyComponent from "@/components/BodyComponent.vue";
    import FooterComponent from "@/components/FooterComponent.vue";
    import Vuetable from "vuetable-2";

    export default {
        components: {
            HeaderComponent,
            BodyComponent,
            FooterComponent,
            Vuetable,
        },
        data() {
            return {
                isCardVisible: false,
                loading: false, // Flag to track whether data is loading
                customerData: [], // Initialize an empty array to store the fetched customer data
            };
        },
        methods: {
            toggleCardVisibility() {
                this.isCardVisible = !this.isCardVisible;
            },
            toggleCardEditVisibility() {
                this.isCardVisible = !this.isCardVisible;
            },
            fetchCustomerData() {
                this.loading = true; // Set loading flag to true
                fetch('https://smartgarageproject.com/adminPanel/unblock/3') // Replace '/api/customers/' with the actual endpoint URL
                    .then(response => {
                        if (!response.ok) {
                            throw new Error('Unauthorized');
                        }
                        return response.json();
                    })
                    .then(data => {
                        this.customerData = data; // Set the fetched data to the customerData array
                    })
                    .catch(error => {
                        console.error('Error fetching customer data:', error);
                        // Handle unauthorized or other errors
                        if (error.message === 'Unauthorized') {
                            // Redirect to login page or show unauthorized message
                            // For example:
                            this.$router.push('/login');
                        }
                    })
                    .finally(() => {
                        this.loading = false; // Set loading flag to false after request completes
                    });
            },
        },
        mounted() {
            // Fetch customer data when the component is mounted
            this.fetchCustomerData();
        }
    };
</script>

<style scoped>

    body {
        margin-top: 20px;
        color: #1a202c;
        text-align: left;
        background-color: #e2e8f0;
    }

    .main-body {
        padding: 15px;
    }

    .card {
        box-shadow: 0 1px 3px 0 rgba(0,0,0,.1), 0 1px 2px 0 rgba(0,0,0,.06);
    }

    .card {
        position: relative;
        display: flex;
        flex-direction: column;
        min-width: 0;
        word-wrap: break-word;
        background-color: #fff;
        background-clip: border-box;
        border: 0 solid rgba(0,0,0,.125);
        border-radius: .25rem;
    }

    .card-body {
        flex: 1 1 auto;
        min-height: 1px;
        padding: 1rem;
    }

    .gutters-sm {
        margin-right: -8px;
        margin-left: -8px;
    }

    .row .gutters-sm {
        width: 204%;
    }

    .gutters-sm > .col, .gutters-sm > [class*=col-] {
        padding-right: 8px;
        padding-left: 8px;
    }

    .mb-3, .my-3 {
        margin-bottom: 1rem !important;
    }

    .bg-gray-300 {
        background-color: #e2e8f0;
    }

    .h-100 {
        height: 100% !important;
    }

    .shadow-none {
        box-shadow: none !important;
    }

    .container {
        position: fixed;
        left: 0;
        top: 10%;
    }
</style>