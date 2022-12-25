using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class arriveCustomer : customerEventData
{
    private GameObject customer;
   // private GameObject car;
    private AudioSource customerSource;
    [SerializeField] private AudioClip getOutOfCar;
    private Vector3 startPos;
    private NavMeshAgent agent;
    private customerProfile customerProfile;
    private List<GameObject> customerProducts = new List<GameObject>();
    void Start()
    {   
        foreach(Transform transform in transform)
        {
            if(transform.gameObject.CompareTag("customer")) customer = transform.gameObject;
           // else if(transform.gameObject.CompareTag("car")) car = transform.gameObject;
        }
        customerProfile = customer.AddComponent<customerProfile>();
        customer.SetActive(false);
        customerSource = customer.GetComponent<AudioSource>();
        agent = customer.GetComponent<NavMeshAgent>();
        
    }

    public void arrive()
    {
        GetComponent<Animation>().Play("arrive");
        InvokeRepeating("customerArrive", 0.1f, 0.1f);
    }
    
    private void customerArrive()
    { 
        if (GetComponent<Animation>().isPlaying) return;
        InvokeRepeating("checkCurrentPosition", 0, 0.1f);
        customer.SetActive(true);
        customerSource.PlayOneShot(getOutOfCar);
        startPos = customer.transform.position;
        agent.SetDestination(buyingPositions[new System.Random().Next(buyingPositions.Count)]);
        customer.GetComponent<Animator>().SetBool("isWalking", true);
        customerProfile.isNearShelving = true;
        CancelInvoke("customerArrive");
    }
    private void customerGotoCasher()
    {
        agent.SetDestination(casherPos);
        customer.GetComponent<Animator>().SetBool("isWalking", true);
        customerProfile.isNearCasher = true;
    }
    
    void checkCurrentPosition()
    {
        if(customerProfile.isNearShelving && Vector3.Distance(customer.transform.position,agent.destination) < 0.5f)
        {
            Debug.Log("ups");
            customerProfile.isNearShelving = false;
            customer.GetComponent<Animator>().SetBool("isWalking", false);
            fillInProfile();
            Invoke("customerGotoCasher", 5);
        }
        else if(customerProfile.isNearCasher && Vector3.Distance(customer.transform.position, agent.destination) < 0.5f)
        {
            Debug.Log("aps");
            customerProfile.isNearCasher = false;
            customer.GetComponent<Animator>().SetBool("isWalking", false);
            isSomeoneWaitingForPay = true;
            currentCustomer = customerProfile;
            customerBalance_float = 0;
            change_float = 0;
            sumOfPrices = 0;
            for (int i = 0; i < currentCustomer.listOfId.Count; i++)
            {
                sumOfPrices += arrayOfProducts[currentCustomer.listOfId[i]].costOfProduct;
            }
            switch (sumOfPrices)
            {
                case < 1:
                    customerBalance_float = 1;
                    break;
                case < 2:
                    customerBalance_float = 3;
                    break;
                case < 4:
                    customerBalance_float = 5;
                    break;
                case < 6:
                    customerBalance_float = 7.5f;
                    break;
                case < 8:
                    customerBalance_float = 10;
                    break;
                case < 12:
                    customerBalance_float = 15;
                    break;
                case < 15:
                    customerBalance_float = 25;
                    break;
                case < 20:
                    customerBalance_float = 27.5f;
                    break;
                case < 30:
                    customerBalance_float = 38.5f;
                    break;
                default:
                    customerBalance_float = 50;
                    break;
            }
            for(int i = 0; i < currentCustomer.listOfId.Count; i++)
            {
               customerProducts.Add(Instantiate(arrayOfProducts[currentCustomer.listOfId[i]].modelOfProduct, placesOnCasher[i],
                    arrayOfProducts[currentCustomer.listOfId[i]].modelOfProduct.transform.rotation));
            }

        }
        else if(isMustGo && Vector3.Distance(customer.transform.position, agent.destination) < 0.5f) 
        {
            CancelInvoke("checkCurrentPosition");
            for(int i = 0; i < customerProducts.Count; i++)
            {
                Destroy(customerProducts[i]);
            }
            
            agent.SetDestination(startPos);
            customer.GetComponent<Animator>().SetBool("isWalking", true);
            InvokeRepeating("customerLeave", 0.1f, 0.1f);
        }
    }
    private void customerLeave()
    {
        if (agent.remainingDistance > 0) return;
        customer.GetComponent<Animator>().SetBool("isWalking", false);
        customerSource.PlayOneShot(getOutOfCar);
        isMustGo = false;
        customer.SetActive(false);
        // GetComponent<Animation>().Play("leave");
        CancelInvoke("customerLeave");
    }
    private void fillInProfile()
    {
       for(int i = 0; i < 6 - new System.Random().Next(6); i++) 
        { 
            customerProfile.listOfId.Add(new System.Random().Next(39));
        }
    }
    
}
