using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class arriveCustomer : customerEventData
{
    private GameObject customer;
    private AudioSource customerSource;
    [SerializeField] private AudioClip getOutOfCar;
    [SerializeField] private AudioClip getInCar;
    private Vector3 startPos;
    private NavMeshAgent agent;
    private customerProfile customerProfile;
    private List<GameObject> customerProducts = new List<GameObject>();
    void Start()
    {   
        foreach(Transform transform in transform)
        {
            if(transform.gameObject.CompareTag("customer")) customer = transform.gameObject;
        }
        customerProfile = customer.AddComponent<customerProfile>();
        customer.SetActive(false);
        customerSource = customer.GetComponent<AudioSource>();
        agent = customer.GetComponent<NavMeshAgent>();
    }

    public IEnumerator arrive()
    {
        GetComponent<Animation>().Play("arrive");//start animation of car and waiting until it ends
        yield return new WaitUntil(() => !GetComponent<Animation>().isPlaying);
        //start checking position of customer and setting random destination for customer 
        InvokeRepeating("checkCurrentPosition", 0, 0.1f);
        customer.SetActive(true);
        customerSource.PlayOneShot(getOutOfCar);
        startPos = customer.transform.position;
        agent.SetDestination(buyingPositions[new System.Random().Next(buyingPositions.Count)]);
        customer.GetComponent<Animator>().SetBool("isWalking", true);
        customerProfile.isNearShelving = true;
        
    }
    
    private IEnumerator gotoCasher()
    {
        customerProfile.isNearShelving = false;
        customer.GetComponent<Animator>().SetBool("isWalking", false);

        for(int i = 0; i < 6 - new System.Random().Next(6); i++) 
        { 
        //creating list for customer with random count of products
        customerProfile.listOfId.Add(new System.Random().Next(39));
        }

        yield return new WaitForSeconds(5);
        //going to casher
        agent.SetDestination(casherPos);
        customer.GetComponent<Animator>().SetBool("isWalking", true);
        customerProfile.isNearCasher = true;
    }
    
    private void onCash()
    {
        customerProfile.isNearCasher = false;
            customer.GetComponent<Animator>().SetBool("isWalking", false);
            //reset values for minigame
            isSomeoneWaitingForPay = true;
            currentCustomer = customerProfile;
            customerBalance_float = 0;
            change_float = 0;
            sumOfPrices = 0;
            
            for (int i = 0; i < currentCustomer.listOfId.Count; i++)
            {//calculate sum of customer's products
                sumOfPrices += arrayOfProducts[currentCustomer.listOfId[i]].costOfProduct;
            }
            //calculating sum of money that customer will give to player
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
            //fill in UI prices, names and photos of products and spawning customer's proucts on casher
            for(int i = 0; i < currentCustomer.listOfId.Count; i++)
            {
               customerProducts.Add(Instantiate(arrayOfProducts[currentCustomer.listOfId[i]].modelOfProduct, placesOnCasher[i],
                    arrayOfProducts[currentCustomer.listOfId[i]].modelOfProduct.transform.rotation));
            }
    }

    private IEnumerator gotoCar()
    {//stopping checking customer's position and deleting products on casher
        CancelInvoke("checkCurrentPosition");
        foreach(var item in customerProducts)
        {
            Destroy(item);
        }
        //customer going to car
        agent.SetDestination(startPos);
        customer.GetComponent<Animator>().SetBool("isWalking", true);

        yield return new WaitUntil(() => Vector3.Distance(customer.transform.position, startPos) < 0.6f);
        //when customer came to car play animation
        customer.GetComponent<Animator>().SetBool("isWalking", false);
        customerSource.PlayOneShot(getInCar);
        isMustGo = false;
        customer.SetActive(false);
        GetComponent<Animation>().Play("left");
    }
    void checkCurrentPosition()
    {
        if(customerProfile.isNearShelving && Vector3.Distance(customer.transform.position,agent.destination) < 0.5f)
        {//if customer came to shelving
            StartCoroutine(gotoCasher());
        }
        else if(customerProfile.isNearCasher && Vector3.Distance(customer.transform.position, agent.destination) < 0.5f)
        {//if customer came to casher
            onCash();
        }
        else if(isMustGo && Vector3.Distance(customer.transform.position, agent.destination) < 0.5f) 
        {//if customer going back to car
            StartCoroutine(gotoCar());
        }
    }
}
