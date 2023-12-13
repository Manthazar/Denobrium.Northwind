# Northwind API Use Cases
There are the following roles envisioned:
- The `customer`/ public
- The `operator` (that is also an employee, not all employees are operators though)
- The `monitor` (that is typically the principal of a tool such as LogicMonitor or the principal of a deployment tool such as Azure DevOps or Octopus)

## REST/ HTTP Supplemented
**The operator can...**
```
- fetch summaries of all customers without secrets
- fetch details of a single customer

- fetch summaries of all registered employees 
- fetch details of a single employee
  
- fetch summaries of all orders
- fetch details of a single order

- fetch summaries of all products
- fetch details of a single product

- fetch summaries of all suppliers
- fetch details of a single supplier
```

**The monitor can...** 
```
- verify the entire configuration of the backend API.
- verify parts of the configuration of the backend API, such as integration/ database.
- request a ping from the backend to signalize its online
- request a ping from siblings of the backend to verify whether they are online
```

## Timer Based
TBD

## Message Based
TBD
