workspace "Learning Center Platform - Vue.js/ASP.NET Core Stack Edition"{

model {
user = person "User" "Someone who wants to manage publishing content"

softwareSystem = softwareSystem "Learning Center Platform" "System for managing content publishing operations" {
webApplication = container "Learning Center Web Application" "Delivers and serves the static content and the Vue.js application" {
tags "webapp"
technology "HTML, CSS, JavaScript"
}

singlePageApplication = container "Learning Center Single Page Application" "Provides web-based interface for managing publishing content using components and services" {
tags "spa"
technology "JavaScript, Vue 3.5.13, PrimeVue 4.3.3, Vue-i18n 10.0.7, Axios 1.9.0, Pinia 3.0.2, Vue-Router 4.5.1"
}

apiApplication = container "Learning Center Platform API Application" "Provides publishing functionality via JSON/HTTPS API" {
tags "api"
technology "C#, ASP.NET, EntityFrameworkCore"
iam = component "IAM Bounded Context" "Manages authentication and access control" "ASP.NET Component"
publishing = component "Publishing Bounded Context" "Handles tutorials, assets, categories, and publishing lifecycle" "ASP.NET Component"
profiles = component "Profiles Bounded Context" "Manages user profile information" "ASP.NET Component"
shared = component "Shared Bounded Context" "Provides shared utilities and abstractions" "ASP.NET Component"
}

database = container "Database" "Stores publishing data including categories" {
tags "database"
technology "MySQL Server"
}
        }

# Context level relationships
user -> softwareSystem "Uses to manage publishing content"

# Container level relationships
user -> webApplication "Visits publishing management website using" "HTTPS"
webApplication -> singlePageApplication "Delivers to browser"
singlePageApplication -> apiApplication "Makes API calls to" "JSON/HTTPS"
apiApplication -> database "Reads from and writes to" "Spring Data JPA"

# Component-level relationships (within API Application)
iam -> database "Reads from and writes to"
publishing -> database "Reads from and writes to"
profiles -> database "Reads from and writes to"
shared -> database "Set ORM Mapping Rules, manages db context"

# Show inter-dependencies between bounded contexts
publishing -> profiles "Get the Profile ID of a User by Email"
profiles -> iam "Get a User by Username / Get a User ID / Create a new User"
# Show dependencies of other bounded contexts on Shared
iam -> shared "Implements interfaces / extends classes from"
publishing -> shared "Implements interfaces / extends classes from"
profiles -> shared "Implements interfaces / extends classes from"

# Show App-Component relationships
singlePageApplication -> publishing -> "Creates Categories, Tutorials, Manages Tutorial lifecycle"
singlePageApplication -> profiles -> "Creates and Get Profiles"
singlePageApplication -> iam -> "Sign-Up and Sign-In"
}

views {
systemContext softwareSystem "SystemContext" {
include *
autoLayout
}

container softwareSystem "Containers" {
include *
autoLayout
}

component apiApplication "Components" {
include *
autoLayout
}

theme default

styles {
element "person" {
shape Person
background #08427B
}

element "webapp" {
shape Box
background #1168BD
}

element "spa" {
shape WebBrowser
background #00BB7A
}

element "api" {
shape Box
background #85BBF0
}

element "database" {
shape Cylinder
background #438DD5
}
        }
    }
}