**Project Overview**: Enterprise-like System with Layered Architecture

This project is an enterprise-like system composed of various layers,
each adhering to the principles of the Onion Architecture.

 

**Shop System**:

-   One of the project modules is the SiteManagement. It handles product
    > creation, product groups, management of product images, and order
    > processing.

-   Products can be organized into different product groups.

-   The system allows an unlimited number of images per product, which
    > can be displayed in product sliders.

-   Order management, including payment status, order tracking numbers,
    > payment IDs, order discounts, and order amounts, is handled by the
    > store system.


    **Discount System**:
-   One of the project modules is the DiscountManagement. This subsystem
    > enables adding discounts to products within specific time
    > intervals and at specific prices.

-   Discounts are applied to the final customer invoice.

-   During checkout, all prices and discounts are calculated and
    > displayed to the user, who can choose between online and cash
    > payment methods.

-   Colleague Discount Panel : The Colleague discount panel allows site
    > administrators to offer products to collaborators at reduced
    > prices.

>                 Discounts applied through this panel are visible on
> collaborators' final invoices.



    **Inventory Management System**:
-   The inventory subsystem tracks inventory statistics, product prices,
    > and product inflow/outflow.

-   When a purchase occurs, the system automatically reduces the
    > inventory for purchased items.

-   Manual adjustments can be made to inventory levels when new items
    > are added.

-   Inventory history (inflow/outflow) is also tracked.



    **Blogging System**:
-   The blogging subsystem allows adding and managing new articles.

-   The article body supports rich text using the TinyMCE service.


    **Site Queries**:
-   Following the **CQRS** pattern, this layer interacts with the
    > database for read-only queries that don't require specific
    > services.

-   Ado.NET is used for improved performance.


    **Anti Corruption Layer ** **(ACL)**:
-   The ACL pattern is employed to manage communication between layers
    > and prevents Tightly Coupled Dependency.



    **Authorization**:
-   Role-based access control is implemented, granting specific
    > permissions to each role.

-   the SecurityPageFilter verifies the access level of authenticated
    > users.

    **APIs**:

-   Some layers have separate APIs, allowing independent usage.
