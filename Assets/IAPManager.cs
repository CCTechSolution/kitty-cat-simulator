using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider storeExtensionProvider;

    // Your product ID (must match App Store Connect + Unity IAP Catalog)
    public const string productId_nonConsumable = "allgrans";

    void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance(AppStore.AppleAppStore));

        // Register non-consumable product
        builder.AddProduct(productId_nonConsumable, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }

    // Call this to start purchase
    public void BuyNonConsumable_allgrans()
    {
        if (storeController != null)
        {
            storeController.InitiatePurchase(productId_nonConsumable);
        }
        else
        {
            Debug.LogWarning("IAPManager: Store not initialized.");
        }
    }

    // Purchase result callback
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (args.purchasedProduct.definition.id == productId_nonConsumable)
        {
            Debug.Log("IAPManager: Non-consumable purchased successfully!");

            UnlockPremiumFeature();
        }

        return PurchaseProcessingResult.Complete;
    }

    public void UnlockPremiumFeature()
    {
        GrannySelection.Instance.UnlockAllGarns();
    }

    // Store init success
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        storeExtensionProvider = extensions;
        Debug.Log("IAPManager: Initialized successfully.");
    }

    // Store init failed
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("IAPManager: Initialization failed: " + error);
    }

    // Purchase failed
    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogWarning($"IAPManager: Purchase failed: {product.definition.id}, {reason}");
    }
    void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
    }
    void IStoreListener.OnInitializeFailed(InitializationFailureReason error, string message)
    {
    }
}
