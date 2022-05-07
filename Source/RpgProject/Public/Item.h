// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "UObject/NoExportTypes.h"
#include "Item.generated.h"

/**
 * 
 */
UCLASS(Abstract, BlueprintType, Blueprintable, EditInLineNew, DefaultToInstanced)
class RPGPROJECT_API UItem : public UObject
{
	GENERATED_BODY()
	
	public:
		UItem();

		UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "Item")
			FText UseActionText;

		UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "Item")
			class UStaticMesh* PickupMesh;

		UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "Item")
			class UTexture2D* Icon;

		UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "Item", meta = (MultiLine = true))
			FText ItemDescription;

		UPROPERTY(EditDefaultsOnly, BlueprintReadWrite, Category = "Item", meta = (ClampMin = 0.0))
			float Weight;

		UPROPERTY()
			class UInventoryComponent* OwningInventory;

		virtual void Use(class APCharacter* Character) PURE_VIRTUAL(UItem, );

		UFUNCTION(BlueprintImplementableEvent)
			void OnUse(class APCharacter* Character);
};
